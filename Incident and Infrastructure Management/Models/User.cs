using System.ComponentModel.DataAnnotations;

namespace Incident_and_Infrastructure_Management.Models
{
    public class User : Base
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Full Name")]
        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(25)]
        [MinLength(3)]
        public string LastName { get; set; }

        [MaxLength(10)]
        [MinLength(10)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]

        [Display(Name = "Email Address")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsEmailVerified { get; set; }
        public Guid? ActivationCode { get; set; }
        public string? ResetPasswordCode { get; set; }
        public string? LastLoginDate { get; set; }
        //public eRole? Role { get; set; }
    }
}
