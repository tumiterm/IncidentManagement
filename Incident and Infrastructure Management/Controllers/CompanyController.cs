using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Incident_and_Infrastructure_Management.Models;
using Incident_and_Infrastructure_Management.Models.Data;
using Incident_and_Infrastructure_Management.Models.ViewModel;
using Incident_and_Infrastructure_Management.Helper;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace Incident_and_Infrastructure_Management.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly INotyfService _notyf;
        public CompanyController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, INotyfService notyf)
        {
            _context = context;

            _webHostEnvironment = webHostEnvironment;

            _notyf = notyf;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Company != null ?
                        View(await _context.Company.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Company'  is null.");
        }
        public async Task<IActionResult> CompanyDetails(Guid? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }
        public IActionResult RegisterCompany()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterCompany(CompanyViewModel companyModel, Guid Ref)
        {
            Ref = Guid.NewGuid();

            string uniqueFileName = UploadedCompanyLogo(companyModel);

            string message = string.Empty;

            Company company = new Company
            {
                Id = Ref,

                Icon = uniqueFileName,

                Name = companyModel.Name,

                Description = companyModel.Description,

                CreatedBy = "Itumeleng Oliphant",

                CreatedOn = DateTime.Now.ToString(),

                IsActive = true,

                Contact = new Contact
                {
                    Id = Guid.NewGuid(),

                    Cellphone = companyModel.Cellphone,

                    Cellphone2 = companyModel.Cellphone2,

                    Email = companyModel.Email,

                    Ref = Ref

                },

                Address = new Address
                {
                    Id = Guid.NewGuid(),

                    ComplexNum = companyModel.ComplexNum,

                    PostalCode = companyModel.PostalCode,

                    Suburb = companyModel.Suburb,

                    Provice = companyModel.Province,

                    Country = companyModel.Country,

                    Type = companyModel.Type,

                    Ref = Ref,
                }
            };

            if (ModelState.IsValid)
            {
                if (companyModel.Cellphone.Length == 10)
                {
                    if (!companyModel.Cellphone.Equals(companyModel.Cellphone2))
                    {
                        _context.Add(company);

                        var rc = await _context.SaveChangesAsync();

                        if (rc > 0)
                        {
                            //ViewBag.Alert = Helper.Utility.ShowAlert(Models.eConfig.eAlerts.Success, $"{company.Name} is successfully registered.");
                            _notyf.Success($"{ company.Name} is successfully registered",2);

                            return RedirectToAction(nameof(RegisterCompany));
                        }
                        else
                        {
                            _notyf.Error($"Error: Company NOT Added!.Please Try again",2);
                        }

                    }
                    else
                    {
                        _notyf.Error("Error: Cellphone1 number cannot be the same as Cellphone2!");
                    }

                }
                else
                {
                    _notyf.Error("Error: Cellphone number has to be 10 numbers long!");
                }

            }

            return View(company);
        }
        public async Task<IActionResult> ModifyCompanyDetails(Guid? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifyCompanyDetails(Guid id, [Bind("Id,Name,Icon")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            return View(company);
        }
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Company == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Company'  is null.");
            }
            var company = await _context.Company.FindAsync(id);

            if (company != null)
            {
                _context.Company.Remove(company);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private bool CompanyExists(Guid id)
        {
            return (_context.Company?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private string UploadedCompanyLogo(CompanyViewModel model)
        {
            string uniqueFileName = null;

            if (model.Icon != null)
            {
                string uploadsFolder = _webHostEnvironment.WebRootPath;

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Icon.FileName;

                string filePath = Path.Combine(uploadsFolder + "/img", uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Icon.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }

}

