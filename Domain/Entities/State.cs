
namespace Domain.Entities;

    public class State : BaseEntity
    {
        public string Name {get;set;}
        public int IdCountryFk {get;set;}
        public Country Country {get;set;}
        public ICollection<Clothing> Clothings {get;set;}
        public ICollection<Municipality> Municipalities {get;set;}


        
    }
