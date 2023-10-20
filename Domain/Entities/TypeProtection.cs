
namespace Domain.Entities;

    public class TypeProtection : BaseEntity
    {
        public string Description {get;set;}
        public ICollection<Clothing> Clothings {get;set;}
        
        
    }
