

namespace Domain.Entities;

    public class TypeStatus : BaseEntity
    {
        public string Description {get;set;}
        
        public ICollection<Status> Status {get;set;}
        
    }
