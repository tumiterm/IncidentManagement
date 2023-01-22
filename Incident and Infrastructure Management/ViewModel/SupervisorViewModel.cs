namespace Incident_and_Infrastructure_Management.ViewModel
{
    public class SupervisorViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Cellphone2 { get; set; }
        public Guid DepartmentId { get; set; }
        public string? Position { get; set; }
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
