
namespace Domain.Entities;

    public class Genre : BaseEntity
    {
        public string Description {get;set;}
        
        public ICollection<Clothing> Clothings {get;set;}
    }
