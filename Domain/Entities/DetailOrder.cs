
namespace Domain.Entities
{
    public class DetailOrder : BaseEntity
    {
        public int AmountProduce {get;set;}
        public int AmountProduced {get;set;}
        public int IdOrderFk {get;set;}
        public Order Order {get;set;}
        public int IdClothingFk {get;set;}
        public Clothing Clothing {get;set;}
        public int IdColorFk {get;set;}
        public Color Color {get;set;}
        public int IdStatusFk {get;set;}
        public Status Status {get;set;}


        
    }
}