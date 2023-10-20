

namespace Domain.Entities;

    public class Sell : BaseEntity
    {
        public DateTime Date {get;set;}
        public int IdEmployeeFk {get;set;}
        public Employee Employee {get;set;}
        public int IdCustomerFk {get;set;}
        public Customer Customer {get;set;}
        public int IdMethodPaymentFk {get;set;}
        public MethodPayment MethodPayment {get;set;}
        
        public ICollection<DetailSell> DetailSells {get;set;}
        
    }
