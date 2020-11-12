using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bdd.Core.Models.DTO
{
    public class ScenarioRequest
    {
        [Required]
        public Guid TicketGuid { get; set; }

        [Required]
        public Guid BoardGuid { get; set; }

        public string Name { get; set; }

    }
}
