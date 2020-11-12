using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Questions.Api.Core.Models.DTO
{
    public class QuestionRequest
    {
        [Required]
        public Guid? ProjectGuid { get; set; }

        [Required]
        public Guid? TicketGuid { get; set; }

        [Required]
        public string Body { get; set; }
    }
}
