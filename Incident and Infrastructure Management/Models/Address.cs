using Incident_and_Infrastructure_Management.Models.eConfig;
using System.ComponentModel.DataAnnotations;

namespace Incident_and_Infrastructure_Management.Models
{
    public class Address
    {
        [Key]
       public Guid Id { get; set; }
       public AddressType Type { get; set; }

       [Display(Name = "Complex/Street Number")]
       public string? ComplexNum { get; set; }
       public string? Suburb { get; set; }
       public eProvince Provice { get; set; }
       public eCountry Country { get; set; }
       public Guid Ref { get; set; }

       [Display(Name = "Postal Code")]
       public string PostalCode { get; set; }

    }
}
