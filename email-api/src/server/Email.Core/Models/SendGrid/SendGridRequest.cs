using Email.Data;
using SendGrid.Helpers.Mail;

namespace Email.Core.Models.SendGrid
{
    public class SendGridRequest
    {
        public EmailAddress[] To { get; set; }

        public EmailAddress[] Cc { get; set; }

        public EmailAddress[] Bcc { get; set; }

        public SendGridDynamicData DynamicTemplateData { get; set; }

        public Enumerations.SendGridTemplateEnum Template { get; set; }
    }
}
