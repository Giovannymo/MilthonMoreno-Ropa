
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class DetailSellRepository : GenericRepository<DetailSell>, IDetailSell
    {
        
        private readonly SkelettonContext _context;

        public DetailSellRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}