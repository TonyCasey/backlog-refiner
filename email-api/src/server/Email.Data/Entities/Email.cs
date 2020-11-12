using System;
using System.Collections.Generic;
using System.Text;

namespace Email.Data.Entities
{
    public class Email : BaseEntity
    {
        public long EmailId { get; set; }

        public Guid ToUserGuid { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid BoardGuid { get; set; }

        public Guid TicketGuid { get; set; }

        public Guid NotificationGuid { get; set; }

        public string SendGridId { get; set; }

    }
}
