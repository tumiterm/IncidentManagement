using Incident_and_Infrastructure_Management.Models.eConfig;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Incident_and_Infrastructure_Management.Models
{
    public class Incident : Base
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Incident Number")]
        [MaxLength(25)]
        [MinLength(5)]
        public string? IncidentNumber { get; set; } = string.Empty;
        public eCategory Category { get; set; }
        public eService Service { get; set; }

        [Display(Name = "Contact Type")]
        public eContactType ContactType { get; set; }
        public eUrgency Urgency { get; set; }
        public eImpact Impact { get; set; }

        [Display(Name = "Current Status")]
        public eResolveStatus? ResolveStatus { get; set; }
        public eState State { get; set; }

        [Display(Name = "Incident Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Upload Evidence")]
        public string? Image { get; set; }

        [Display(Name = "Assign to")]
        public Guid? SupervisorId { get; set; }
        public string Location { get; set; } = string.Empty;

        [Display(Name = "Recommeded Date of Repair")]
        public DateTime Date { get; set; }

        [Display(Name = "Contact Person")]
        [MinLength(3)]
        public string ContactPerson { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;

        [Display(Name = "Is Call Closed?")]
        public bool IsClosedCall { get; set; }

        [Display(Name = "Is Call Closed?")]
        public bool IsAttendedTo { get; set; }
        public DateTime? AttendedOn { get; set; }

        [NotMapped]
        public IFormFile? UploadImage { get; set; }
    }
}
