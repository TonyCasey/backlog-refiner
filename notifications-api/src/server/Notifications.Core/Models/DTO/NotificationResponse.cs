using System;
using System.Collections.Generic;
using System.Text;
using static Notifications.Data.Enumerations;

namespace Notifications.Core.Models.DTO
{
    public class NotificationResponse
    {
        public DateTime CreationTime { get; set; }

        public Guid Guid { get; set; }

        public Guid TicketGuid { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid UserGuid { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public StatusEnum StatusId { get; set; }

        public DateTime? ReadDate { get; set; }

        public DateTime? ClickDate { get; set; }
    }
}
