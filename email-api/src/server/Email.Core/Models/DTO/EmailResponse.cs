using System;
using System.Collections.Generic;
using System.Text;

namespace Email.Core.Models.DTO
{
    public class EmailResponse
    {
        public Guid Guid { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid ToUserGuid { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid BoardGuid { get; set; }

        public Guid TicketGuid { get; set; }

        public Guid? NotificationGuid { get; set; }

    }
}
