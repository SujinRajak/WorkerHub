using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;


namespace EmailHandler
{
    internal class Message
    {
        public List<MailAddress> To { get; set; }
        public List<MailAddress> CC { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public List<Attachment> Attachments { get; set; }

        public Message(IEnumerable<string> mailTO, IEnumerable<string> mailCC, string subject, string HTMLBody, IEnumerable<string> PathsToAttachments)
        {
            try
            {
                To = new List<MailAddress>();
                CC = new List<MailAddress>();
                Attachments = new List<Attachment>();
                if (mailTO != null)
                    To.AddRange(mailTO.Select(x => new MailAddress(x.Trim())));
                if (mailCC != null)
                    CC.AddRange(mailCC.Select(x => new MailAddress(x.Trim())));
                if (PathsToAttachments != null)
                    Attachments.AddRange(PathsToAttachments.Select(x => new Attachment(x.Trim())));
                Subject = subject;
                Content = HTMLBody;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in message component parameters. " + ex.Message);
            }
        }
    }
}
