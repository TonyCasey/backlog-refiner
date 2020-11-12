using System;
using System.Collections.Generic;
using System.Text;
using static Notifications.Data.Enumerations;

namespace Notifications.Data.Entities
{
    public class Notification : BaseEntity
    {
        public long NotificationId { get; set; }

        public Guid UserGuid { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid BoardGuid { get; set; }

        public Guid? TicketGuid { get; set; }

        public Guid? QuestionGuid { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public StatusEnum StatusId { get; set; } = StatusEnum.Unread;

        public DateTime? ReadDate { get; set; }

        public DateTime? ClickDate { get; set; }
    }
}
