
namespace Domain.Entities;

    public class Municipality : BaseEntity
    {
        public string Name {get;set;}
        public int IdStateFk {get;set;}
        public State State {get;set;}
    
        public ICollection<Company> Companies {get;set;}
        public ICollection<Customer> Customers {get;set;}
        public ICollection<Employee> Employees {get;set;}
        
        public ICollection<Supplier> Suppliers {get;set;}
        
        
    }
