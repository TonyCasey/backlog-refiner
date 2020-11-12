using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Data.Entities
{
    public class Task : BaseEntity
    {
        public long TaskId { get; set; }

        public string Body { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid TicketGuid { get; set; }

        public Guid BoardGuid { get; set; }

        public Guid UserGuid { get; set; }

    }
}
