using Incident_and_Infrastructure_Management.Models.eConfig;
using Microsoft.AspNetCore.Mvc;

namespace Incident_and_Infrastructure_Management.Controllers
{
    public class TestController : BaseController
    {
        public IActionResult Index()
        {
            Alert("This is a success message", eAlerts.success);

            return View();
        }
    }
}
