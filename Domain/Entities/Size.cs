
namespace Domain.Entities;

    public class Size : BaseEntity
    {
        public string Description {get;set;}
        
        public ICollection<DetailSell> DetailSells {get;set;}  
        public ICollection<Size> Sizes {get;set;}


    }
