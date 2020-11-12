using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tasks.Core.Models.DTO
{
    public class TaskRequest
    {
        [Required]
        public string Body { get; set; }

        [Required]
        public Guid? TicketGuid { get; set; }

        [Required]
        public Guid? BoardGuid { get; set; }
    }
}
