using System;
using System.Collections.Generic;
using System.Text;

namespace Email.Core.Models.SendGrid
{
    public class SendGridDynamicData
    {
        public string Sender_Name { get; set; } = "BackLog Refiner";

        public string Sender_Address { get; set; } = "Sky Business Center, 57 Clontarf Road";

        public string Sender_City { get; set; } = "Clontarf";

        public string Sender_State { get; set; } = "Dublin";

        public string Sender_Zip { get; set; } = "D3";

        public string Unsubscribe { get; set; } = "https://app.backlogrefiner.com/settings/email";

        public Guid TicketGuid { get; set; }

        public string BaseUrl { get; set; }

    }
}
