using Incident_and_Infrastructure_Management.Models.eConfig;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Incident_and_Infrastructure_Management.Models
{
    public class Company : Base
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Company Name")]
        public string Name { get; set; }
        public string Icon { get; set; }
        public Contact? Contact { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
