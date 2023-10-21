
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace VeterinaryApi.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]


public class CitationController : BaseApiController 
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    public CitationController(IUnityOfWork unityOfWork,IMapper mapper)
    {
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    [MapToApiVersion("1.0")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CitationDto>>> Get()
    {
        var citations = await _unityOfWork.Citations.GetAllAsync();
        return _mapper.Map<List<CitationDto>>(citations);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CitationDto>> Post(CitationDto citationDto)
    {
        var citation = _mapper.Map<Citation>(citationDto);
        _unityOfWork.Citations.Add(citation);
        await _unityOfWork.SaveAsync();

        if (citation == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = citation.Id}, citationDto);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CitationDto>> Put(int id, [FromBody] CitationDto citationDto)
    {
        if (citationDto == null) return NotFound();
        var citation = _mapper.Map<Citation>(citationDto);
        _unityOfWork.Citations.Update(citation);
        await _unityOfWork.SaveAsync();
        return citationDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var citation = await _unityOfWork.Citations.GetByIdAsync(id);
        if (citation == null) return NotFound();
        _unityOfWork.Citations.Remove(citation);
        await _unityOfWork.SaveAsync();
        return NoContent();
    }
}