using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bdd.Core.Models.DTO
{
    public class ScenarioSearchRequest
    {
        public Guid? ScenarioGuid { get; set; }

        public Guid? UserGuid { get; set; }

        public Guid? BoardGuid { get; set; }

        [Required]
        public Guid TicketGuid { get; set; }
    }
}
