
namespace Domain.Entities;

    public class InputClothing : BaseEntity
    {
        public int IdInputFk {get;set;}
        public Input Input {get;set;}
        public int IdClothingFk {get;set;}
        public Clothing Clothing {get;set;}

        
    }
