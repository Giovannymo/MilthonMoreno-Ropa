
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;
    
    public class CustomerRepository : GenericRepository<Customer>, ICustomer
    {
        
        private readonly SkelettonContext _context;

        public CustomerRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
