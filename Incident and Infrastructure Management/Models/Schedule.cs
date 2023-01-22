using System.ComponentModel.DataAnnotations;

namespace Incident_and_Infrastructure_Management.Models
{
    public class Schedule
    {
        [Key]
        public Guid ScheduleId { get; set; }
        public Guid AssociationId { get; set; }
        public bool IsAvailableMonday { get; set; }
        public bool IsAvailableTues { get; set; }
        public bool IsAvailableWed { get; set; }
        public bool IsAvailableThurs { get; set; }
        public bool IsAvailableFrid { get; set; }
        public bool IsAvailableSat { get; set; }
        public bool IsAvailableSund { get; set; }
    }
}
