using Incident_and_Infrastructure_Management.Models.Contract;
using Incident_and_Infrastructure_Management.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Incident_and_Infrastructure_Management.Models.BusinessLayer
{
    public class IncidentRepository : IUnitofWork<Incident>
    {
        private readonly ApplicationDbContext _db;
        public IncidentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Incident> ModifyRecordAsync(Incident t)
        {
            var results = await _db.Incident.FirstOrDefaultAsync(m => m.Id == t.Id);

            if(results != null)
            {
                results.SupervisorId = t.SupervisorId;

                results.Category = t.Category;

                results.ContactType = t.ContactType;

                results.CreatedBy = t.CreatedBy;

                results.CreatedOn = t.CreatedOn;

                results.Date = t.Date;

                results.Description = t.Description;

                results.Image = t.Image;

                results.Impact = t.Impact;

                results.IsActive = t.IsActive;

                results.Location = t.Location;

                results.ModifiedBy = t.ModifiedBy;

                results.ModifiedOn = t.ModifiedOn;

                results.ResolveStatus = t.ResolveStatus;

                results.Service = t.Service;

                results.State = t.State;

                results.IsClosedCall = t.IsClosedCall;

                results.Urgency = t.Urgency;

                await _db.SaveChangesAsync();

                return results;
            }
            return null;
        }

        public async Task<Incident> OnGetRecordAsync(Guid Id)
        {
            var record = await _db.Incident.FirstOrDefaultAsync(e => e.Id == Id);

            return record;
        }

        public async Task<IEnumerable<Incident>> OnGetRecordsAsync()
        {
            return await _db.Incident.ToListAsync();
        }

        public async Task<Incident> RegisterRecordAsync(Incident t)
        {
            var record = await _db.Incident.AddAsync(t);

            await _db.SaveChangesAsync();

            return record.Entity;

        }

        public void RemoveRecordAsync(Guid Id)
        {
            var results = _db.Incident.FirstOrDefault(m => m.Id == Id);

            if (results != null)
            {
                 _db.Incident.Remove(results);

                 _db.SaveChangesAsync();
            }
        }

        public void SaveRecordAsync()
        {
            _db.SaveChangesAsync();
        }
    }
}
