using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tickets.Api.Data.Entities
{
    public class Ticket : BaseEntity
    {
        public long TicketId { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid BoardGuid { get; set; }

        public Guid UserGuid { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public Guid StatusGuid { get; set; }
    }
}
