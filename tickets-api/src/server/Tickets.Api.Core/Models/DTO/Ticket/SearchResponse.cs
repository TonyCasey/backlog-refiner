using System.Collections.Generic;

namespace Tickets.Api.Core.Models.DTO.Ticket
{
    public class SearchResponse
    {
        public List<TicketResponseModel> Data { get; set; }
    }
}
