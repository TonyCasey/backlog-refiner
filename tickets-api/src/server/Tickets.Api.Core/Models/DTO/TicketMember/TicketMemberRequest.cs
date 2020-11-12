using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tickets.Api.Core.Models.DTO.TicketMember
{
    public class TicketMemberRequest
    {
        [Required]
        public Guid? TicketGuid { get; set; }

        [Required]
        public Guid? TeamUserGuid { get; set; }

        [Required]
        public Guid? UserGuid { get; set; }
    }
}
