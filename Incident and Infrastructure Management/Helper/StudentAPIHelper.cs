namespace Incident_and_Infrastructure_Management.Helper
{
    public class StudentAPIHelper
    {
        public HttpClient Initialize(string baseAddress)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(baseAddress);

            return client;
        }
    }
}
