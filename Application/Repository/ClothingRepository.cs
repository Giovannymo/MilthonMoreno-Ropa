
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class ClothingRepository : GenericRepository<Clothing>, IClothing
    {
        
        private readonly SkelettonContext _context;

        public ClothingRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}