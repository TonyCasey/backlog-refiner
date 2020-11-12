using System;
using System.Collections.Generic;
using System.Text;
using static Notifications.Data.Enumerations;

namespace Notifications.Core.Models.DTO
{
    public class SearchRequest
    {
        public Guid? UserGuid { get; set; }

        public Guid? TicketGuid { get; set; }

        public Guid? QuestionGuid { get; set; }

        public Guid? BoardGuid { get; set; }

        public StatusEnum StatusId { get; set; } 

    }
}
