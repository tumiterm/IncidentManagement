using Incident_and_Infrastructure_Management.Models.eConfig;
using Microsoft.AspNetCore.Mvc;

namespace Incident_and_Infrastructure_Management.Controllers
{
    public class BaseController : Controller
    {
        public void Alert(string message, eAlerts notificationType)
        {
            var msg = "<script language='javascript'>swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "</script>";
            TempData["notification"] = msg;
        }

        /// <summary>
        /// Sets the information for the system notification.
        /// </summary>
        /// <param name="message">The message to display to the user.</param>
        /// <param name="notifyType">The type of notification to display to the user: Success, Error or Warning.</param>
        public void Message(string message, eAlerts notifyType)
        {
            TempData["Notification2"] = message;

            switch (notifyType)
            {
                case eAlerts.success:
                    TempData["NotificationCSS"] = "alert-box success";
                    break;
                case eAlerts.error:
                    TempData["NotificationCSS"] = "alert-box errors";
                    break;
                case eAlerts.warning:
                    TempData["NotificationCSS"] = "alert-box warning";
                    break;

                case eAlerts.info:
                    TempData["NotificationCSS"] = "alert-box notice";
                    break;
            }
        }
    }
}
