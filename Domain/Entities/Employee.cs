
namespace Domain.Entities;

    public class Employee : BaseEntity
    {
        public string Name {get;set;}
        public DateTime JoinDate {get;set;}
        public int IdJobTitle {get;set;}
        public JobTitle JobTitle {get;set;}
        public int IdMunicipalityFk {get;set;}
        public Municipality Municipality {get;set;}
           
        public ICollection<Order> Orders {get;set;}
        public ICollection<Sell> Sells {get;set;}
    }




