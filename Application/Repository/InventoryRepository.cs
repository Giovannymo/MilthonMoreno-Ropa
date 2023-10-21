
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class InventoryRepository : GenericRepository<Inventory>, IInventory
    {
        
        private readonly SkelettonContext _context;

        public InventoryRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}