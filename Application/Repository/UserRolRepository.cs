
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class UserRolRepository : GenericRepository<UserRol>, IUserRol
    {
        
        private readonly SkelettonContext _context;

        public UserRolRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}