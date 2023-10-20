
namespace Domain.Entities;

    public class InventorySize : BaseEntity
    {
        public int Amount {get;set;}
        public int IdInventoryFk {get;set;}
        public Inventory Inventory {get;set;}
        public int IdSizeFk {get;set;}
        public Size Size {get;set;}

        

        
    }
