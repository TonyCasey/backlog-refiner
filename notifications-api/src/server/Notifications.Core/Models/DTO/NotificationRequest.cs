using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Notifications.Data.Enumerations;

namespace Notifications.Core.Models.DTO
{
    public class NotificationRequest
    {
        [Required]
        public Guid? TicketGuid { get; set; }

        [Required]
        public Guid? BoardGuid { get; set; }

        [Required]
        public Guid? UserGuid { get; set; }

        public Guid? QuestionGuid { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public StatusEnum? StatusId { get; set; } = StatusEnum.Unread;

        public DateTime? ReadDate { get; set; }

        public DateTime? ClickDate { get; set; }
    }
}
