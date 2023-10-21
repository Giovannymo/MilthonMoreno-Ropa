
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class InputClothingRepository : GenericRepository<InputClothing>, IInputClothing
    {
        
        private readonly SkelettonContext _context;

        public InputClothingRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}