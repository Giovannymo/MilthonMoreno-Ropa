
namespace Domain.Entities;

    public class CompanyDto
    {
        public int Nit {get;set;}
        public string ReasonSocial {get;set;}
        public string LegalRepresentative {get;set;}
        public DateTime DateCreation {get;set;}
        public int IdMunicipalityFk {get;set;}

        
    }
