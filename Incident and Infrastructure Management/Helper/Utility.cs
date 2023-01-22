using Incident_and_Infrastructure_Management.Models.Data;
using Incident_and_Infrastructure_Management.Models.eConfig;
using System.Linq.Expressions;

namespace Incident_and_Infrastructure_Management.Helper
{
    public static class Utility
    {

        private static readonly ApplicationDbContext _dbContext;
        public static Guid OnGenerateGuid()
        {
            return Guid.NewGuid();
        }

        public static bool DoesExist<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : class
        {
            IQueryable<TEntity> data = _dbContext.Set<TEntity>();
            return data.Any(predicate);

            //use as IsExist<Order>(x => x.IncidentId == Id);
        }

        public static bool OnSendSMSNotification()
        {
            return true;
        }

        public static string ShowAlert(eAlerts obj, string message)
        {
            string alertDiv = null;

            switch (obj)
            {
                case eAlerts.success:
                    alertDiv = "<div class='alert alert-success alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Success!</ strong > " + message + "</a>.</div>";
                    break;

                case eAlerts.error:
                    alertDiv = "<div class='alert alert-danger alert-dismissible' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Error!</ strong > " + message + "</a>.</div>";
                    break;

                case eAlerts.info:
                    alertDiv = "<div class='alert alert-info alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Info!</ strong > " + message + "</a>.</div>";
                    break;

                case eAlerts.warning:
                    alertDiv = "<div class='alert alert-warning alert-dismissable' id='alert'><button type='button' class='close' data-dismiss='alert'>×</button><strong> Warning!</strong> " + message + "</a>.</div>";
                    break;
            }

            return alertDiv;
        }
    }
}
