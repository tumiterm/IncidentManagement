using Microsoft.EntityFrameworkCore;

namespace Incident_and_Infrastructure_Management.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Schedule> Schedule { get; set; }

        public DbSet<Department> Department { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Incident> Incident { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Student> Student { get; set; }










    }
}
