using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Api.Data.Entities
{
    public class Project : BaseEntity
    {
        public long ProjectId { get; set; }

        public Guid Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid UserGuid { get; set; }

        public Guid TeamGuid { get; set; }
    }
}
