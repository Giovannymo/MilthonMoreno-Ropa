
namespace Domain.Entities;

    public class Size : BaseEntity
    {
        public string Description {get;set;}
        public ICollection<Inventory> Inventories = new HashSet<Inventory>();
        public ICollection<DetailSell> DetailSells {get;set;}  
        public ICollection<InventorySize> InventorySizes {get;set;}  

        


    }
