using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Api.Data.Entities
{
    public class Question : BaseEntity
    {
        public long QuestionId { get; set; }

        public Guid Guid { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid ProjectGuid { get; set; }

        public Guid UserGuid { get; set; }

        public Guid TicketGuid { get; set; }

        public string Body { get; set; }

        public bool? Deleted { get; set; }
    }
}
