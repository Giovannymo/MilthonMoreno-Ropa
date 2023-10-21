
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class SellRepository : GenericRepository<Sell>, ISell
    {
        
        private readonly SkelettonContext _context;

        public SellRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}