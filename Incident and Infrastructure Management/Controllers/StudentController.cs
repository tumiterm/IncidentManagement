using Incident_and_Infrastructure_Management.Helper;
using Incident_and_Infrastructure_Management.Models;
using Incident_and_Infrastructure_Management.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using RestSharp;

namespace Incident_and_Infrastructure_Management.Controllers
{
    public class StudentController : Controller
    {
        StudentAPIHelper apiHelper = new StudentAPIHelper();
        public async Task<IActionResult> StudentList()
        {
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

            return View(students);
        }

        public async Task<IActionResult> StudentDetails(string StudentNumber, Guid? StudentId)
        {
            Student getResponse = await GetStudent(StudentNumber);

            if (getResponse == null)
            {
                NotFound();
            }

            return View(getResponse);
        }


        [NonAction]
        public string GenerateToken()
        {
            var client = new RestClient("http://forekapi.dreamline-ict.co.za/authenticate/?Username=forekapi@forekinstitute.co.za&Password=api.P@ssw0rd");

            var request = new RestRequest();

            var body = new User { Username = "forekapi@forekinstitute.co.za", Password = "api.P@ssw0rd" };

            request.AddJsonBody(body);

            var response = client.Post(request);

            string content = response.Content.Substring(31,280);

            if (!response.IsSuccessful)
            {
                ViewData["data"] = "Error: Server encountered an error";
            }

            return content;
        }

        public async Task<Student> GetStudent(string StudentNumber)
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
                res = response.Content.ToString();

                student = JsonConvert.DeserializeObject<Student>(res);

                EnrollmentHistoryViewModel enrollment = new EnrollmentHistoryViewModel
                {
                    CourseId = student.EnrollmentHistory[0].CourseId,

                    DateCompleted = student.EnrollmentHistory[0].DateCompleted,

                    StartDate = student.EnrollmentHistory[0].StartDate,

                    CourseTitle = student.EnrollmentHistory[0].CourseTitle,

                    StudentId = student.EnrollmentHistory[0].StudentId,

                    CourseType = student.EnrollmentHistory[0].CourseType,

                    EnrollmentId = student.EnrollmentHistory[0].EnrollmentId,

                    EnrollmentStatus = student.EnrollmentHistory[0].EnrollmentStatus,

                    IsActive = student.EnrollmentHistory[0].IsActive

                }; 

                if(enrollment is null)
                {
                    
                }
                else
                {

                }

            }

            return student;
        }

        [NonAction]

        //public void GetAll()
        //{
        //    string url = "http://forekapi.dreamline-ict.co.za/api/Students";

        //    var client = new RestClient(url);

        //    var request = new RestRequest();

        //    request.AddHeader("Authorization", " Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1bmlxdWVfbmFtZSI6ImZvcmVrYXBpQGZvcmVraW5zdGl0dXRlLmNvLnphIiwibmFtZWlkIjoiYXBpLlBAc3N3MHJkIiwiaXNzIjoic2VsZiIsImF1ZCI6Imh0dHA6Ly93d3cuZXhhbXBsZS5jb20iLCJleHAiOjE2NTgwNjQ4NDksIm5iZiI6MTY1ODA2MTI0OX0.CrREnudRuU5MCD_YGu29NrJ_nGcL1gx1z0AvRD_5PDs");

        //    var response = client.Get(request);

        //    if (response.IsSuccessful)
        //    {
        //        //var results = response.Content.ReadAsStringAsync()
        //    }



        //}

        public void SendSMS()
        {
            var client = new RestClient("https://www.winsms.co.za/api/rest/v1/sms/outgoing/send/");

            var request = new RestRequest();

            request.AddHeader("Authorization", "2C9DAABE-20FE-4BC1-9BF3-276D9BBC9699");

            SMSViewModel sms = new SMSViewModel
            {
                message = "Test Message from System",

                recipients = new List<Recipient>
                {
                    new Recipient { mobileNumber = "0614422285"}
                }

            };

            request.AddJsonBody(sms);

            var response = client.Post(request);

            string content = response.Content.ToString();

            if (!response.IsSuccessful)
            {
                ViewData["data"] = "Bad Request";
            }

        }
    }
}
