using Incident_and_Infrastructure_Management.Models.eConfig;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Incident_and_Infrastructure_Management.Models
{
    public class IncidentReport: Base
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Incident")]
        public Guid IncidentId { get; set; }
        public string ReportNumber { get; set; }
        public Supervisor ReportedBy { get; set; }
        public string? IncidentCause { get; set; }
        public string? IncidentDescription { get; set; }
        public string? Recommendation { get; set; }
        public string Date { get; set; }
        public eStatus Status { get; set; }



    }
}
