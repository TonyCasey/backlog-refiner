using System;
using System.Collections.Generic;
using System.Text;

namespace Comments.Core.DTO
{
    public class SearchModel
    {
        public Guid UserGuid { get; set; }

        public Guid CommentGuid { get; set; }

        public Guid TicketGuid { get; set; }

        public Guid QuestionGuid { get; set; }
    }
}
