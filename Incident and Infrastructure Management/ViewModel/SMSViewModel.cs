namespace Incident_and_Infrastructure_Management.Models.ViewModel
{
    public class Recipient
    {
        public string mobileNumber { get; set; }
        public string? clientMessageId { get; set; }
    }
    public class SMSViewModel
    {
        public string message { get; set; }
        public List<Recipient> recipients { get; set; }
        public string? scheduledTime { get; set; }
        public int? maxSegments { get; set; }
    }


  

  


}

