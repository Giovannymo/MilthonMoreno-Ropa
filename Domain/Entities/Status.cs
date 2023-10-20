

namespace Domain.Entities;

    public class Status : BaseEntity
    {
        public string Description {get;set;}
        public int IdTypeStatusFk {get;set;}
        public TypeStatus TypeStatus {get;set;}
        
        public ICollection<DetailOrder> DetailOrders {get;set;}
        public ICollection<Order> Orders {get;set;}
        
    }
