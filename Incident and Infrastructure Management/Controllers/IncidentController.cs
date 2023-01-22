using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Incident_and_Infrastructure_Management.Models;
using Incident_and_Infrastructure_Management.Models.Data;
using Incident_and_Infrastructure_Management.Models.Contract;
using Incident_and_Infrastructure_Management.Helper;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Incident_and_Infrastructure_Management.Controllers
{
    public class IncidentController : Controller
    {
        private readonly IUnitofWork<Incident> _incidentRepo;
        private readonly IUnitofWork<Supervisor> _supervisor;
        private readonly INotyfService _notyf;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public IncidentController(IUnitofWork<Incident> incidentRepo, IWebHostEnvironment webHostEnvironment, INotyfService notyf, IUnitofWork<Supervisor> supervisor)
        {
            _incidentRepo = incidentRepo;

            _webHostEnvironment = webHostEnvironment;

            _notyf = notyf;

            _supervisor = supervisor;

        }
        public async Task<IActionResult> OnGetIncidentsList()
        {
            //return _context.Incident != null ? 
            //            View(await _context.Incident.ToListAsync()) :
            //            Problem("Entity set 'ApplicationDbContext.Incident'  is null.");

            return _incidentRepo.OnGetRecordsAsync != null ?
                                 View(await _incidentRepo.OnGetRecordsAsync()) :
                                 Problem("Entity set 'ApplicationDbContext.Incident'  is null.");

        }
        public async Task<IActionResult> OnGetIncidentDetail(Guid id)
        {
            //if (_context.Incident == null)
            //{
            //    return NotFound();
            //}

            //var incident = await _context.Incident
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var incident = await _incidentRepo.OnGetRecordAsync(id);

            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }
        public async Task<IActionResult> OnLogIncident()
        {
            var supervisors = await _supervisor.OnGetRecordsAsync();

            IEnumerable<SelectListItem> getSupervisors = from n in supervisors

                                                   select new SelectListItem
                                                   {
                                                       Value = n.Id.ToString(),

                                                       Text = $"{n.LastName} {n.Name} | {n.Position}"
                                                   };

            ViewBag.SupervisorId = new SelectList(getSupervisors, "Value", "Text");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnLogIncident(Incident incident)
        {
            incident.IncidentNumber = $"FIT-Inc/{DateTime.Now.Year}/";

            incident.ResolveStatus = Models.eConfig.eResolveStatus.InProgress;

            if (ModelState.IsValid)
            {
                incident.Id = Utility.OnGenerateGuid();

                incident.IsActive = true;

                incident.Image = UploadedEvidence(incident);

                incident.CreatedOn = "";

                incident.CreatedBy = "";

                incident.IsClosedCall = false;

                incident.IsClosedCall = false;

                var rc = await _incidentRepo.RegisterRecordAsync(incident);

                if(rc != null)
                {
                    _incidentRepo.SaveRecordAsync();

                    _notyf.Success("Incident successfully reported");

                    return RedirectToAction(nameof(OnLogIncident));
                }
                else
                {
                    _notyf.Error("Error: Incident NOT registered",3);

                }
            }
            return View(incident);
        }
        public async Task<IActionResult> UpdateIncidentDetails(Guid id)
        {
            //if (id == null || _context.Incident == null)
            //{
            //    return NotFound();
            //}
            var incident = await _incidentRepo.OnGetRecordAsync(id);

            if (incident == null)
            {
                return NotFound();
            }
            return View(incident);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateIncidentDetails(Guid id, [Bind("Id,IncidentNumber,Category,Service,ContactType,Urgency,Impact,ResolveStatus,State,Description,Image,Location,Date,IsActive,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] Incident incident)
        {
            if (id != incident.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _incidentRepo.ModifyRecordAsync(incident);

                    _incidentRepo.SaveRecordAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Utility.DoesExist<Incident>(x => x.Id == incident.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(incident);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            //if (id == null || _context.Incident == null)
            //{
            //    return NotFound();
            //}
            var incident = await _incidentRepo.OnGetRecordAsync(id);

            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            //if (_context.Incident == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Incident'  is null.");
            //}

            var incident = await _incidentRepo.OnGetRecordAsync(id);

            if (incident != null)
            {
                _incidentRepo.RemoveRecordAsync(id);
            }

            _incidentRepo.SaveRecordAsync();

            return RedirectToAction(nameof(Index));
        }
        private string UploadedEvidence(Incident model)
        {
            string uniqueFileName = null;

            if (model.UploadImage != null)
            {
                string uploadsFolder = _webHostEnvironment.WebRootPath;

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.UploadImage.FileName;

                string filePath = Path.Combine(uploadsFolder + "/img", uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.UploadImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}


