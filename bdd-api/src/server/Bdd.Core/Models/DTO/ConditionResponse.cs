using Bdd.Data;
using System;

namespace Bdd.Core.Models.DTO
{
    public class ConditionResponse
    {
        public Guid Guid { get; set; }

        public Guid ScenarioGuid { get; set; }

        public Enumerations.OperatorEnum OperatorId { get; set; }

        public string Body { get; set; }
    }
}
