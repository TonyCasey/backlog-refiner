using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tasks.Core.Models.DTO
{
    public class TaskSearchRequest
    {
        public Guid? TicketGuid { get; set; }

        public Guid? BoardGuid { get; set; }
    }
}
