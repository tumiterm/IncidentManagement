using Incident_and_Infrastructure_Management.Models.eConfig;
using Incident_and_Infrastructure_Management.Models.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace Incident_and_Infrastructure_Management.Models
{
    public class Student : Base
    {
        public Guid StudentId { get; set; }
        public int YearOfStudy { get; set; }
        public Contact contact { get; set; }

        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; } = string.Empty;

        [Display(Name = "Admission Date")]
        public DateTime AdmissionDate { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "ID Number")]
        public string? IDNumber { get; set; } = string.Empty;

        [Display(Name = "Study Permit Number")]
        public string? StudyPermitNumber { get; set; } = string.Empty;

        [Display(Name = "Passport Number")]
        public string? PassportNumber { get; set; } = string.Empty;

        [Display(Name = "Date of Birth")]
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; } = string.Empty;

        [Display(Name = "Place of Birth")]
        public string? PlaceofBirth { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;

        [Display(Name = "Admission Category")]
        public string AdmissionCategory { get; set; } = string.Empty;

        [Display(Name = "Street AddressLine1")]
        public string StreetAddressLine1 { get; set; } = string.Empty;
        public string StreetAddressLine2 { get; set; } = string.Empty;
        public string StreetAddressCity { get; set; } = string.Empty;
        public string StreetAddressCode { get; set; } = string.Empty;
        public string PostAddressLine1 { get; set; } = string.Empty;
        public string PostAddressLine2 { get; set; } = string.Empty;
        public string PostAddressCity { get; set; } = string.Empty;
        public string PostAddressCode { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Cellphone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HighestGrade { get; set; } = string.Empty;
        public string NameofSchool { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool Deregistered { get; set; }
        public List<EnrollmentHistoryViewModel>? EnrollmentHistory { get; set; }

    }
}

