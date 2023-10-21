
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class TypeProtectionRepository : GenericRepository<TypeProtection>, ITypeProtection
    {
        
        private readonly SkelettonContext _context;

        public TypeProtectionRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}