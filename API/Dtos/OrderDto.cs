
namespace Domain.Entities;

    public class OrderDto
    {
        public DateTime Date {get;set;}
        public int IdEmployeeFk {get;set;}
        public int IdCustomerFk {get;set;}
        public int IdStatusFk {get;set;}

        
    }
