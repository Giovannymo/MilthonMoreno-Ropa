
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class TypePersonRepository : GenericRepository<TypePerson>, ITypePerson
    {
        
        private readonly SkelettonContext _context;

        public TypePersonRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}