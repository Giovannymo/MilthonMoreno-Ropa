
namespace Domain.Entities;

    public class TypePerson : BaseEntity
    {
        public string Name {get;set;}
        
        public ICollection<Customer> Customers {get;set;}
        
        public ICollection<Supplier> Suppliers {get;set;}        
    }
