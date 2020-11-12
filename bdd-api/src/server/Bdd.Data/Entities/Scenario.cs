using System;
using System.Collections.Generic;
using System.Text;

namespace Bdd.Data.Entities
{
    public class Scenario : BaseEntity
    {
        public long ScenarioId { get; set; }

        public Guid UserGuid { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid TicketGuid { get; set; }

        public Guid BoardGuid { get; set; }

        public string Name { get; set; }

        public List<Condition> Conditions { get; set; }

    }
}
