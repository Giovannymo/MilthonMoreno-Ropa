
namespace Domain.Entities;

    public class JobTitle : BaseEntity
    {
        public string Description {get;set;}
        public double BaseSalary {get;set;}
        
        public ICollection<Employee> Employees {get;set;}
        
    }


