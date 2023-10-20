

namespace Domain.Entities;

    public class Customer : BaseEntity
    {
        public string Name {get;set;}
        public DateTime JoinDate {get;set;}
        public int IdTypePersonFk {get;set;}
        public TypePerson TypePerson {get;set;}
        public int IdMunicipalityFk {get;set;}
        public Municipality Municipality {get;set;}
        
        public ICollection<Sell> Sells {get;set;}
        
        public ICollection<Order> Orders {get;set;}
        
    }
