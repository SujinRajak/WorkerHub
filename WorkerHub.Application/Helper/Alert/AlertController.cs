using Microsoft.AspNetCore.Mvc;

namespace WorkerHub.Application.Helper.Alert
{
    public partial class AlertController : Controller
    {
        public void Success(string message, bool dismissable)
        {
            AddAlert(AlertStyle.Success, message, dismissable);
        }
        public void Danger(string message, bool dismissable)
        {
            AddAlert(AlertStyle.Danger, message, dismissable);
        }

        public void Information(string message, bool dismissable)
        {
            AddAlert(AlertStyle.Information, message, dismissable);
        }

        public void Warning(string message, bool dismissable)
        {
            AddAlert(AlertStyle.Warning, message, dismissable);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            var alert = TempData.ContainsKey(Alert.TempKey) ? (List<Alert>)TempData[Alert.TempKey] : new List<Alert>();

            alert.Add(new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            TempData.Put(Alert.TempKey, alert);
            //TempData[Alert.TempKey] = alert;    
        }
    }
}
