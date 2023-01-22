using AspNetCoreHero.ToastNotification.Abstractions;

namespace Incident_and_Infrastructure_Management.Helper
{
    public class NotificationCentre
    {
        private readonly INotyfService _notyf;

        public NotificationCentre()
        {

        }
        public NotificationCentre(INotyfService notyf)
        {
            _notyf = notyf;
        }

        public void OnShowMessage(string message, string status, int? time)
        {
            switch (status)
            {
                case "success":
                    _notyf.Success(message, time);
                    break;

                case "error":
                    _notyf.Error(message, time);
                    break;

                case "warning":
                    _notyf.Warning(message, time);
                    break;
            }
        }


    }
}
