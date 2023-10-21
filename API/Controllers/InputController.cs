/* using API.Dtos;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using API.Helpers;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class InputController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InputController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<InputDto>>> Get()
    {
        var input = await _unitOfWork.Inputs.GetAllAsync();
        return _mapper.Map<List<InputDto>>(input);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Inputs.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<InputDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InputDto>> Post(InputDto appointmentDto)
    {
        var input = _mapper.Map<Appointment>(appointmentDto);
        _unitOfWork.Inputs.Add(input);
        await _unitOfWork.SaveAsync();
        if (input == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = input.Id}, appointmentDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InputDto>> Put(int id, [FromBody] InputDto appointmentDto)
    {
        if (appointmentDto == null) return NotFound();
        var input = _mapper.Map<Appointment>(appointmentDto);
        _unitOfWork.Inputs.Update(input);
        await _unitOfWork.SaveAsync();
        return appointmentDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var input = await _unitOfWork.Inputs.GetByIdAsync(id);
        if (input == null) return NotFound();
        _unitOfWork.Inputs.Remove(input);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    /* Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023 
    [HttpGet("MonthsAndMotive")]
    [MapToApiVersion("1.0")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public object GetForMonthsAndMotive([FromQuery] Params queryParams)
    {
        var search = _unitOfWork.Inputs.GetForMonthsAndMotive(queryParams.MonthInit, queryParams.MonthFinish, queryParams.Reason);
        return _mapper.Map<List<PetOwnerDto>>(search);
    }

    [HttpGet("Veterinarian")]
    [MapToApiVersion("1.0")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PetDto>>> GetPerVeterinario([FromQuery] Params _params)
    {
        var data = await _unitOfWork.Inputs.GetForVeterinarian(_params.Search);
        var search = _mapper.Map<List<PetDto>>(data);
        return search;
 
    }
} 
**/