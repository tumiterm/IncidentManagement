using Incident_and_Infrastructure_Management.Models.Contract;
using Incident_and_Infrastructure_Management.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Incident_and_Infrastructure_Management.Models.BusinessLayer
{
    public class DepartmentRepository : IUnitofWork<Department>
    {
        private readonly ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Department> ModifyRecordAsync(Department t)
        {
            var results = await _db.Department.FirstOrDefaultAsync(m => m.DepartmentId == t.DepartmentId);

            if (results != null)
            {
                
                results.CreatedBy = t.CreatedBy;

                results.CreatedOn = t.CreatedOn;

                results.DepartmentId = t.DepartmentId;

                results.DepartmentName = t.DepartmentName;

                results.Description = t.Description;

                results.IsActive = t.IsActive;

                results.ModifiedBy = t.ModifiedBy;

                results.ModifiedOn = t.ModifiedOn;

                await _db.SaveChangesAsync();

                return results;
            }
            return null;
        }

        public async Task<Department> OnGetRecordAsync(Guid Id)
        {
            var record = await _db.Department.FirstOrDefaultAsync(e => e.DepartmentId == Id);

            return record;
        }

        public async Task<IEnumerable<Department>> OnGetRecordsAsync()
        {
            return await _db.Department.ToListAsync();
        }

        public async Task<Department> RegisterRecordAsync(Department t)
        {
            var record = await _db.Department.AddAsync(t);

            await _db.SaveChangesAsync();

            return record.Entity;

        }

        public void RemoveRecordAsync(Guid Id)
        {
            var results = _db.Department.FirstOrDefault(m => m.DepartmentId == Id);

            if (results != null)
            {
                _db.Department.Remove(results);

                _db.SaveChangesAsync();
            }
        }

        public void SaveRecordAsync()
        {
            _db.SaveChangesAsync();
        }
    }
}
