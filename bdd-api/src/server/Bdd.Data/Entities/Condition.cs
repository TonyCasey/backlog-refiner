using System;
using System.Collections.Generic;
using System.Text;

namespace Bdd.Data.Entities
{
    public class Condition : BaseEntity
    {
        public long ConditionId { get; set; }

        public long ScenarioId { get; set; }

        public Guid ScenarioGuid { get; set; }

        public Guid UserGuid { get; set; }

        public Guid CompanyGuid { get; set; }

        public Enumerations.OperatorEnum OperatorId { get; set; }

        public string Body { get; set; }
    }
}
