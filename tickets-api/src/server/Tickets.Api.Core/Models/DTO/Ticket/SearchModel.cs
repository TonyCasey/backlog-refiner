using System;

namespace Tickets.Api.Core.Models.DTO.Ticket
{
    public class SearchModel
    {
        public Guid? UserGuid { get; set; }

        public Guid? BoardGuid { get; set; }

        public Guid? TicketGuid { get; set; }

        public Guid? StatusGuid { get; set; }

    }
}
