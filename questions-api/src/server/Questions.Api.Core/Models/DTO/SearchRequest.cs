using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Api.Core.Models.DTO
{
    public class SearchRequest
    {
        public Guid UserGuid { get; set; }

        public Guid TicketGuid { get; set; }

        public Guid ProjectGuid { get; set; }

        public Guid QuestionGuid { get; set; }
    }
}
