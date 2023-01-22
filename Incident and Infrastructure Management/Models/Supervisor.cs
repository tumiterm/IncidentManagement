using System.ComponentModel.DataAnnotations;

namespace Incident_and_Infrastructure_Management.Models
{
    public class Supervisor : Base
    {
        [Key]
        public Guid Id { get; set; }
        [MinLength(3)]
        [MaxLength(25)]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;
        [Display(Name="Last Name")]
        [MinLength(3)]
        [MaxLength(25)]
        public string LastName { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MinLength(10)]
        [MaxLength(10)]
        [Display(Name="Primary Cellphone")]
        public string Cellphone { get; set; }

        [Display(Name = "Secondary Cellphone")]
        [MaxLength(10)]
        public string Cellphone2 { get; set; }
        public Guid DepartmentId { get; set; }
        public string? Position { get; set; }
        public Schedule Availability { get; set; }
    }
}
