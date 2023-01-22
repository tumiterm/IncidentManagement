using Incident_and_Infrastructure_Management.Models;

namespace Incident_and_Infrastructure_Management.Contract
{
    public interface IStudent
    {
        Task<Student> GetStudentAsync(string StudentNumber);
        Task<List<Student>> GetAllStudentsAsync();
    }
}
