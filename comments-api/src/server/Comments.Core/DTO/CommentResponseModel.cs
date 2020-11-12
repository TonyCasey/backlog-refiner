using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Comments.Core.DTO
{
    public class CommentResponseModel
    {
        public Guid Guid { get; set; }

        public DateTime CreationTime { get; set; }

        [Required]
        public Guid TicketGuid { get; set; }

        [Required]
        public string Body { get; set; }

    }
}
