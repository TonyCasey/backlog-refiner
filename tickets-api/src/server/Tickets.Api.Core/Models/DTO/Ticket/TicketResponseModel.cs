using System;
using Newtonsoft.Json;

namespace Tickets.Api.Core.Models.DTO.Ticket
{
    public class TicketResponseModel
    {
        public Guid Guid { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid CreationUserGuid { get; set; }

        public string Description { get; set; }

        public string Summary { get; set; }


        [JsonProperty("user")]
        public Guid UserGuid { get; set; }

        [JsonProperty("status")]
        public Guid StatusGuid { get; set; }

        public Guid BoardGuid { get; set; }
    }
}
