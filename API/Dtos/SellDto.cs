

namespace Domain.Entities;

    public class SellDto
    {
        public DateTime Date {get;set;}
        public int IdEmployeeFk {get;set;}
        public int IdCustomerFk {get;set;}
        public int IdMethodPaymentFk {get;set;}
    }
