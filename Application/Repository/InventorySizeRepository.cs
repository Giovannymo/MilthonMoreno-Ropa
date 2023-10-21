
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class  InventorySizeRepository : GenericRepository<InventorySize>, IInventorySize

    {
        
        private readonly SkelettonContext _context;

        public InventorySizeRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}