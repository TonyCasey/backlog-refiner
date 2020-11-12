using System;
using System.Collections.Generic;
using System.Text;

namespace Bdd.Core.Models.DTO
{
    public class ScenarioResponse
    {
        public DateTime CreationTime { get; set; }

        public Guid Guid { get; set; }

        public Guid TicketGuid { get; set; }

        public Guid BoardGuid { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid UserGuid { get; set; }

        public string Name { get; set; }
    }
}
