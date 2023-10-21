
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class MethodPaymentRepository : GenericRepository<MethodPayment>, IMethodPayment
    {
        
        private readonly SkelettonContext _context;

        public MethodPaymentRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}