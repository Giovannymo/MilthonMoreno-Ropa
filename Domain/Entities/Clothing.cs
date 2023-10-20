
namespace Domain.Entities;

    public class Clothing : BaseEntity
    {
        public string Name {get;set;}
        public double ValueUnitCop {get;set;}
        public double ValueUnitUsd {get;set;}
        public int IdStateFk {get;set;}
        public State State {get;set;}
        public int IdTypeProtectionFk {get;set;}
        public TypeProtection TypeProtection {get;set;}
        public int IdGenreFk {get;set;}
        public Genre Genre {get;set;}
        public ICollection<Input> Inputs = new HashSet<Input>();//Cuando es many to many se pone en cada tabla involucrado
        public ICollection<DetailOrder> DetailOrders {get;set;}
        public ICollection<DetailSell> DetailSells {get;set;}   
        public ICollection<InputClothing> InputClothings {get;set;}
        public ICollection<Inventory> Inventories {get;set;}

        
    }
