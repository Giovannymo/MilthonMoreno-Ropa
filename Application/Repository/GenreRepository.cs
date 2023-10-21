
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenre
    {
        
        private readonly SkelettonContext _context;

        public GenreRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}