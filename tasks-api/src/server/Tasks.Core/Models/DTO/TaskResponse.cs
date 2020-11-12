using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Core.Models.DTO
{
    public class TaskResponse
    {
        public Guid Guid { get; set; }

        public string Body { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid TicketGuid { get; set; }

        public Guid BoardGuid { get; set; }
    }
}
