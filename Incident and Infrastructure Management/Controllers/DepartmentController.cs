using Incident_and_Infrastructure_Management.Models;
using Incident_and_Infrastructure_Management.Models.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Incident_and_Infrastructure_Management.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IUnitofWork<Department> _context;
        public DepartmentController(IUnitofWork<Department> context)
        {
            _context = context;  
        }

        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDepartment(Department department)
        {

            if (ModelState.IsValid)
            {
                department.DepartmentId = Helper.Utility.OnGenerateGuid();

                department.IsActive = true;

                department.CreatedBy = "Itumeleng Oliphant";

                department.CreatedOn = DateTime.Now.ToString();

                var rc = await _context.RegisterRecordAsync(department);

                if(rc is null)
                {
                    //record NOT saved display error - message
                }

                //else all went well
            }
            return View();
        }

    }
}
