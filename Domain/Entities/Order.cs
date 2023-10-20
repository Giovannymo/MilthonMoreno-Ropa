
namespace Domain.Entities;

    public class Order : BaseEntity
    {
        public DateTime Date {get;set;}
        public int IdEmployeeFk {get;set;}
        public Employee Employee {get;set;}
        public int IdCustomerFk {get;set;}
        public Customer Customer {get;set;}
        public int IdStatusFk {get;set;}
        public Status Status {get;set;}

        public ICollection<DetailOrder> DetailOrders {get;set;}
        
    }
