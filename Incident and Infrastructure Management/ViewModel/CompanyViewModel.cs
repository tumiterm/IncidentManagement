using Incident_and_Infrastructure_Management.Models.eConfig;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Incident_and_Infrastructure_Management.Models.ViewModel
{
    public class CompanyViewModel
    {
       
        public Guid Id { get; set; }
        public AddressType Type { get; set; }
        public string? ComplexNum { get; set; }
        public string? Suburb { get; set; }
        public eProvince Province { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public IFormFile Icon { get; set; }
        public Guid? RecordId { get; set; }
        public string Cellphone { get; set; } = String.Empty;
        public string? Email { get; set; }
        public string? Cellphone2 { get; set; }
        public string Description { get; set; }
        public eCountry Country { get; set; }




    }
}
