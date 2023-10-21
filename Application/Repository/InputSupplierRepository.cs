
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class InputSupplierRepository : GenericRepository<InputSupplier>, IInputSupplier
    {
        
        private readonly SkelettonContext _context;

        public InputSupplierRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}