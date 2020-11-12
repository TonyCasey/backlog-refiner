using System.Collections.Generic;
using Tickets.Api.Core.Models.DTO.Ticket;

namespace Tickets.Api.Core.Models.DTO.TicketMember
{
    public class TicketMemberSearchResponse
    {
        public List<TicketMemberResponse> Data { get; set; }
    }
}
