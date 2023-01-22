using AspNetCoreHero.ToastNotification.Abstractions;
using Incident_and_Infrastructure_Management.Models;
using Incident_and_Infrastructure_Management.Models.Contract;
using Incident_and_Infrastructure_Management.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Incident_and_Infrastructure_Management.Controllers
{
    public class SupervisorController : Controller
    {
        private readonly IUnitofWork<Supervisor> _context;
        private readonly IUnitofWork<Department> _dept;


        private readonly INotyfService _notyf;

        public SupervisorController(IUnitofWork<Supervisor> context, INotyfService notyf, IUnitofWork<Department> dept)
        {
            _context = context;

            _notyf = notyf;

            _dept = dept;
        }

        [HttpGet]
        public async Task<IActionResult> RegisterSupervisor()
        {
            var departments = await _dept.OnGetRecordsAsync();

            IEnumerable<SelectListItem> getDepts = from s in departments

                                                      select new SelectListItem
                                                      {
                                                          Value = s.DepartmentId.ToString(),

                                                          Text = $"Dept: {s.DepartmentName}"
                                                      };

            ViewBag.DepartmentId = new SelectList(getDepts, "Value", "Text");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterSupervisor(SupervisorViewModel model)
        {
            Guid supervisorId = Helper.Utility.OnGenerateGuid();

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.Cellphone2))
                {
                    if (model.Cellphone.Equals(model.Cellphone2))
                    {
                        _notyf.Error("Error: Cellphone 1 & 2 cannot be the same");
                    }
                }

                Supervisor supervisor = new Supervisor
                {
                    Id = supervisorId,

                    Cellphone = model.Cellphone,

                    Cellphone2 = model.Cellphone2,

                    DepartmentId = model.DepartmentId,

                    Email = model.Email,

                    LastName = model.LastName,

                    Name = model.Name,

                    Availability = new Schedule
                    {
                        ScheduleId = Helper.Utility.OnGenerateGuid(),

                        IsAvailableMonday = model.IsAvailableMonday,

                        IsAvailableTues = model.IsAvailableTues,

                        IsAvailableWed = model.IsAvailableWed,

                        IsAvailableThurs = model.IsAvailableThurs,

                        IsAvailableFrid = model.IsAvailableFrid,

                        IsAvailableSat = model.IsAvailableSat,

                        IsAvailableSund = model.IsAvailableSund,

                        AssociationId = supervisorId
                    },

                    Position = model.Position,

                    IsActive = true,

                    CreatedBy = "Itumeleng Oliphant",

                    CreatedOn = DateTime.Now.ToString()
                };

                var rc = await _context.RegisterRecordAsync(supervisor);

                if(rc != null)
                {
                    _notyf.Success("Supervisor added successfully", 2);

                    return View(nameof(RegisterSupervisor));
                }
                else
                {
                    _notyf.Error("Error: Something went wrong");
                }
            }
            else
            {
                _notyf.Error("Error: Model validity error");
            }

            return View();
        }
    }
}
