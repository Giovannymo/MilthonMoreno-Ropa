
namespace Domain.Entities;

    public class DetailSell : BaseEntity
    {
        public int Amount {get;set;}
        public int ValueUnit {get;set;}
        public int IdSellFk {get;set;}
        public Sell Sell {get;set;}
        public int IdProductFk {get;set;}
        public Clothing Clothing {get;set;}
        public int IdSizeFk {get;set;}
        public Size Size {get;set;}

        
    }
