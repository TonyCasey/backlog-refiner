using Bdd.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bdd.Core.Models.DTO
{
    public class ConditionRequest
    {
        [Required]
        public Guid TicketdGuid { get; set; }

        [Required]
        public Guid BoardGuid { get; set; }

        [Required]
        public Guid ScenarioGuid { get; set; }

        [Required]
        public Enumerations.OperatorEnum OperatorId { get; set; }

        [Required]
        public string Body { get; set; }
    }
}
