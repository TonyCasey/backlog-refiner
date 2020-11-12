using System;
using System.Collections.Generic;
using System.Text;

namespace Email.Core.Models.DTO
{
    public class EmailSearchRequest
    {
        public Guid ToUserGuid { get; set; }

        public Guid TicketGuid { get; set; }

        public Guid NotificationGuid { get; set; }
    }
}
