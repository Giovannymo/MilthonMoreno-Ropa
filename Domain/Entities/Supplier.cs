
namespace Domain.Entities;

    public class Supplier : BaseEntity
    {
        public int NitSupplier {get;set;}
        public string Name {get;set;}
        public int IdTypePersonFk {get;set;}
        public TypePerson TypePerson {get;set;}
        public int IdMunicipalityFk {get;set;}
        public Municipality Municipality {get;set;}
        public ICollection<Input> Inputs = new HashSet<Input>();
        public ICollection<InputSupplier> InputSuppliers {get;set;}
        
    }
