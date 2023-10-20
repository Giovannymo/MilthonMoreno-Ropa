
namespace Domain.Entities;

    public class MethodPayment : BaseEntity
    {
        public string Description {get;set;}
        
        public ICollection<Sell> Sells{get;set;}
        
    }
