using System;
using System.Collections.Generic;
using System.Text;

namespace Sts.Data.Entities
{
    public class Team : BaseEntity
    {
        public long TeamId { get; set; }

        public Guid Guid { get; set; } = Guid.NewGuid();

        public Guid CompanyGuid { get; set; }

        public Guid OwnerGuid { get; set; }

        public string Name { get; set; }

    }
}
