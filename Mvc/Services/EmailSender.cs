using EmailHandler;
using Mvc.Interfaces;

namespace Mvc.Services.Email
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var emails = new List<string>() { email };
                SendEmail sendEmail = new SendEmail();
                await Task.Run(() => sendEmail.Send(emails, null, subject, htmlMessage, null));
            }
            catch (Exception ex)
            {
               // Log.Error(ex, ex.Message);
            }
        }

        public async Task SendEmailAsync(List<string> emailList, List<string> ccEmailList, string subject, string htmlMessage, List<string> attachmentPathList)
        {
            try
            {
                SendEmail sendEmail = new SendEmail();
                await Task.Run(() => sendEmail.Send(emailList, ccEmailList, subject, htmlMessage, attachmentPathList));
            }
            catch (Exception ex)
            {

               // Log.Error(ex, ex.Message);
            }
        }
        public void SendEmail(string email, string subject, string htmlMessage)
        {
            try
            {
                var emails = new List<string>() { email };
                Task.Run(() => new SendEmail().Send(emails, null, subject, htmlMessage, null));
            }
            catch (Exception ex)
            {

                throw;
            }
        
        }
        public void SendEmail(List<string> emailList, List<string> ccEmailList, string subject, string htmlMessage, List<string> attachmentPathList)
        {
            try
            {
                Task.Run(() => new SendEmail().Send(emailList, ccEmailList, subject, htmlMessage, attachmentPathList));
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
