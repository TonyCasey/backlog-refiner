using System;
using System.Collections.Generic;
using System.Text;

namespace Tickets.Api.Data.Entities
{
    public class TicketMember : BaseEntity
    {

        public long TicketMemberId { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid TicketGuid { get; set; }

        public Guid TeamUserGuid { get; set; }

        public Guid UserGuid { get; set; }

    }
}
