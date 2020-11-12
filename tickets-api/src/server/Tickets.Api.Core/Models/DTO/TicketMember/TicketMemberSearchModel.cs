using System;
using System.Collections.Generic;
using System.Text;

namespace Tickets.Api.Core.Models.DTO.TicketMember
{
    public class TicketMemberSearchModel
    {
        public Guid? TicketGuid { get; set; }
        
        public Guid? TeamUserGuid { get; set; }

        public Guid? UserGuid { get; set; }
    }
}
