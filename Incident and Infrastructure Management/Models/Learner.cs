namespace Incident_and_Infrastructure_Management.Models
{
    public class Learner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Guid? SupervisorId { get; set; }



    }
}
