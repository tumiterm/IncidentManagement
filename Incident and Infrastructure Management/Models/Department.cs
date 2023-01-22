using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Incident_and_Infrastructure_Management.Models
{
    public class Department : Base
    {
        [Key]
        public Guid DepartmentId { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
