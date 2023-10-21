
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrder
    {
        
        private readonly SkelettonContext _context;

        public OrderRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}