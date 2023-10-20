
namespace Domain.Entities;

    public class InputSupplier : BaseEntity
    {

        public int IdInputFk {get;set;}
        public Input Input {get;set;}
        public int IdSupplierFk {get;set;}
        public Supplier Supplier {get;set;}        
    }
