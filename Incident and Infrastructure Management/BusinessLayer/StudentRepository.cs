using Incident_and_Infrastructure_Management.Contract;
using Incident_and_Infrastructure_Management.Helper;
using Incident_and_Infrastructure_Management.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Incident_and_Infrastructure_Management.BusinessLayer
{
    public class StudentRepository : IStudent
    {
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            StudentAPIHelper apiHelper = new StudentAPIHelper();

            string token = GenerateToken();

            List<Student> students = new List<Student>();

            HttpClient client = apiHelper.Initialize("http://forekapi.dreamline-ict.co.za/api/Students/");

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage res = await client.GetAsync("http://forekapi.dreamline-ict.co.za/api/Students/");

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;

                students = JsonConvert.DeserializeObject<List<Student>>(results);
            }

            return students;
        }

        public async Task<Student> GetStudentAsync(string StudentNumber)
        {
            string res = string.Empty;

            Student student = new Student();

            var client = new RestClient($"http://forekapi.dreamline-ict.co.za/api/Student?StudentNumber={StudentNumber}");

            var request = new RestRequest();

            request.AddParameter("StudentNumber", StudentNumber);

            request.AddHeader("Authorization", $"Bearer {GenerateToken()}");

            var response = await client.ExecuteGetAsync(request);

            if (response.IsSuccessful)
            {
                student = JsonConvert.DeserializeObject<Student>(res);
            }

            return student;
        }

        public string GenerateToken()
        {
            var client = new RestClient("http://forekapi.dreamline-ict.co.za/authenticate/?Username=forekapi@forekinstitute.co.za&Password=api.P@ssw0rd");

            var request = new RestRequest();

            var body = new User { Username = "forekapi@forekinstitute.co.za", Password = "api.P@ssw0rd" };

            request.AddJsonBody(body);

            var response = client.Post(request);

            return response.Content.Substring(31, 280);
        }
    }
}
