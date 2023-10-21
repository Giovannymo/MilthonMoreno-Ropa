
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class MunicipalityRepository : GenericRepository<Municipality>, IMunicipality
    {
        
        private readonly SkelettonContext _context;

        public MunicipalityRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}