namespace Email.Core.Models.SendGrid
{
    public class SendGridConfigurationOptions
    {
        public string ApiKey { get; set; }

        public string BaseUrl { get; set; }

        public string AddedToTicketTemplate { get; set; }

        public string TicketUpdatedTemplate { get; set; }

        public string FromEmailAddress { get; set; }

        public string FromAlias { get; set; }

        public string ReplyToEmailAddress { get; set; }
    }
}
