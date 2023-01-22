using Incident_and_Infrastructure_Management.Models;
using Incident_and_Infrastructure_Management.Models.Contract;
using Incident_and_Infrastructure_Management.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Incident_and_Infrastructure_Management.BusinessLayer
{
    public class SupervisorRepository : IUnitofWork<Supervisor>
    {
        private readonly ApplicationDbContext _db;
        public SupervisorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Supervisor> ModifyRecordAsync(Supervisor t)
        {
            var results = await _db.Supervisors.FirstOrDefaultAsync(m => m.Id == t.Id);

            if (results != null)
            {
                results.Name = t.Name;

                results.LastName = t.LastName;


                results.IsActive = t.IsActive;

                results.ModifiedBy = t.ModifiedBy;

                results.ModifiedOn = t.ModifiedOn;

         
                
                await _db.SaveChangesAsync();

                return results;
            }
            return null;
        }

        public async Task<Supervisor> OnGetRecordAsync(Guid Id)
        {
            var record = await  _db.Supervisors.FirstOrDefaultAsync(e => e.Id == Id);

            return record;
        }

        public async Task<IEnumerable<Supervisor>> OnGetRecordsAsync()
        {
            return await _db.Supervisors.ToListAsync();
        }

        public async Task<Supervisor> RegisterRecordAsync(Supervisor t)
        {
            var record = await _db.Supervisors.AddAsync(t);

            await _db.SaveChangesAsync();

            return record.Entity;

        }

        public void RemoveRecordAsync(Guid Id)
        {
            var results = _db.Supervisors.FirstOrDefault(m => m.Id == Id);

            if (results != null)
            {
                _db.Supervisors.Remove(results);

                _db.SaveChangesAsync();
            }
        }

        public void SaveRecordAsync()
        {
            _db.SaveChangesAsync();
        }
    }
}
