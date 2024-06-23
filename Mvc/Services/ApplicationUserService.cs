using Mvc.Interfaces;
using Mvc.ViewModel;
using Microsoft.VisualBasic;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Services
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly IEmailSender _emailService;
        public ApplicationUserService(IEmailSender emailService)
        {
            _emailService = emailService;
        }
       
        public void SendEmail(EmailConfirmationModel emailConfirmationModel, string emailTemplatePath)
        {
            try
            {
                string EmailBodyCommon = string.Empty;
                //var updateStatusUrl = $"{game.BaseURL}p/{token}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), emailTemplatePath);
                var emailConfirmationLink = emailConfirmationModel.EmailConfirmationLink;
                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        EmailBodyCommon = reader.ReadToEnd();
                    }
                    EmailBodyCommon = EmailBodyCommon.Replace("{UserName}", emailConfirmationModel.UserName);
                    EmailBodyCommon = EmailBodyCommon.Replace("{EmailConfirmationLink}", emailConfirmationLink);
                    EmailBodyCommon = EmailBodyCommon.Replace("{Password}", emailConfirmationModel.Password);
                }
                string subject = "Email Confirmation";
                _emailService.SendEmail(emailConfirmationModel.UserName ?? "", subject, EmailBodyCommon);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
    }
}
