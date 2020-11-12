using System;
using System.ComponentModel.DataAnnotations;

namespace Tickets.Api.Core.Models.DTO.Ticket
{
    public class TicketRequestModel
    {
        [Required]
        public string Summary { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Guid StatusGuid { get; set; }

        [Required]
        public Guid BoardGuid { get; set; }
        
    }
}
