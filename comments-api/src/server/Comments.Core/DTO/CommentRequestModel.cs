using System;
using System.Collections.Generic;
using System.Text;

namespace Comments.Core.DTO
{
    public class CommentRequestModel
    {

        public Guid TicketGuid { get; set; }

        public Guid QuestionGuid { get; set; }

        public string Body { get; set; }
    }
}
