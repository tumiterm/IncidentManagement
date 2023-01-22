using Incident_and_Infrastructure_Management.Models.eConfig;

namespace Incident_and_Infrastructure_Management.Models
{
    public class ServiceGroup : Base
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
        public Supervisor GroupHead { get; set; }
        public eAvailability Availability { get; set; }
        public eSpeciality Speciality { get; set; }
        public float HourlyRate { get; set; }
        public List<Student> Students { get; set; }
        public string Description { get; set; }
        //public string GroupRating { get; set; }




    }
}
