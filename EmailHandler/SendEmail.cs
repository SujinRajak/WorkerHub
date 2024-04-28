using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace EmailHandler
{
    public class SendEmail
    {
        EmailConfiguration settingConfig = new EmailConfiguration();
        Message message;
        public SendEmail()
        {
            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json").Build();
            configuration.GetSection("smtpMailSettings").Bind(settingConfig);
            var context = new ValidationContext(settingConfig, null, null);
            var ValMessages = new List<ValidationResult>();
            bool IsValid = Validator.TryValidateObject(settingConfig, context, ValMessages, true);
            if (!IsValid)
            {
                throw new Exception("EmailHelper component exception: Issue related mailsettings section in appsettings.json file.");
            }

        }
        public void Send(IEnumerable<string> mailTO, IEnumerable<string> mailCC, string subject, string HTMLBody, IEnumerable<string> PathsToAttachments)
        {
            try
            {
                message = new Message(mailTO, mailCC, subject, HTMLBody, PathsToAttachments);
                MailMessage emailMessage = CreateEmailMessage(message);
                Send(emailMessage);
            }
            catch (Exception ex)
            {
                //Log.Error(ex, "EmailHelper component exception: ");
            }

        }
        private MailMessage CreateEmailMessage(Message message)
        {
            MailMessage mail = new MailMessage();
            message.To.ForEach(x => mail.To.Add(x));
            message.CC.ForEach(x => mail.CC.Add(x));
            mail.From = new MailAddress(settingConfig.From);
            mail.Subject = message.Subject;
            mail.IsBodyHtml = true;
            mail.Body = message.Content;
            mail.IsBodyHtml = true;
            message.Attachments.ForEach(x => mail.Attachments.Add(x));
            return mail;
        }
        private void Send(MailMessage mailMessage)
        {
            using (SmtpClient client = new SmtpClient())
            {
                try
                {
                    ////client.UseDefaultCredentials = false;
                    client.Host = settingConfig.Host;
                    client.Port = settingConfig.Port;
                    if (settingConfig.Username != null && settingConfig.Password != null)
                    {
                        client.Credentials = new System.Net.NetworkCredential(settingConfig.Username, settingConfig.Password);
                    }
                    client.EnableSsl = settingConfig.EnableSsl;
                    client.Send(mailMessage);
                    // Log.Information($"E-mail sent to {mailMessage.To.Select(x => x.Address).Aggregate((x, y) => x + " " + y)}");
                }
                catch (Exception ex)
                {
                    throw new Exception("E-mail delivery failed." + ex.Message);
                }
            }
        }

    }
}
