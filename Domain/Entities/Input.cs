

namespace Domain.Entities;

    public class Input : BaseEntity
    {
        public string Name {get;set;}
        public int ValueUnit {get;set;}
        public int StockMin {get;set;}
        public int StockMax {get;set;}
        
        public ICollection<InputClothing> InputClothings {get;set;}
        public ICollection<InputSupplier> InputSuppliers {get;set;}
    
        
    }
