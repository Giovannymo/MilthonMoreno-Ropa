

namespace Domain.Entities;

    public class Inventory : BaseEntity
    {
        public int CodInventory {get;set;}
        public double ValueSellCop {get;set;}
        public double ValueSellUsd {get;set;}
        public int IdClothingFk {get;set;}
        public Clothing Clothing {get;set;}
        public ICollection<Size> Sizes = new HashSet<Size>();
        public ICollection<InventorySize> InventorySizes {get;set;}
        
        
    }
