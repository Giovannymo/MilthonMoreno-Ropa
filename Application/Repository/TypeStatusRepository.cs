
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class TypeStatusRepository : GenericRepository<TypeStatus>, ITypeStatus
    {
        
        private readonly SkelettonContext _context;

        public TypeStatusRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}