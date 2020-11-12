using System;
using System.Collections.Generic;
using System.Text;

namespace Comments.Data.Entities
{
    public class Comment : BaseEntity
    {
        public long CommentId { get; set; }

        public Guid Guid { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid UserGuid { get; set; }

        public Guid TicketGuid { get; set; }

        public Guid QuestionGuid { get; set; }

        public string Body { get; set; }

        public bool? Deleted { get; set; }
    }
}
