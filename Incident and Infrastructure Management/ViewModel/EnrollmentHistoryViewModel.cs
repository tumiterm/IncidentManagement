using System.ComponentModel.DataAnnotations;

namespace Incident_and_Infrastructure_Management.Models.ViewModel
{
    public class EnrollmentHistoryViewModel
    {
        [Key]
        public string EnrollmentId { get; set; }
        public Guid StudentId { get; set; }
        public Guid? CourseId { get; set; }

        [Display(Name = "Course")]
        public string CourseTitle { get; set; }

        [Display(Name = "Course Type")]
        public string CourseType { get; set; }

        [Display(Name = "Enrollement Status")]
        public string EnrollmentStatus { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Date Completed")]
        public DateTime DateCompleted { get; set; }
        public bool IsActive { get; set; }
    }
}
