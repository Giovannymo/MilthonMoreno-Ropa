
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class JobTitleRepository : GenericRepository<JobTitle>, IJobTitle
    {
        
        private readonly SkelettonContext _context;

        public JobTitleRepository(SkelettonContext context) : base(context)
        {
            _context = context;
        }
    }
}