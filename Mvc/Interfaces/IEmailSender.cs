using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mvc.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(List<string> emailList, List<string> ccEmailList, string subject, string htmlMessage, List<string> attachmentPathList);
        Task SendEmailAsync(string email, string subject, string htmlMessage);
        void SendEmail(string email, string subject, string htmlMessage);
        void SendEmail(List<string> emailList, List<string> ccEmailList, string subject, string htmlMessage, List<string> attachmentPathList);
    }
}