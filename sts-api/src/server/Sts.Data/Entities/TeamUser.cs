using System;
using System.Collections.Generic;
using System.Text;

namespace Sts.Data.Entities
{
    public class TeamUser : BaseEntity
    {
        public long TeamUserId { get; set; }

        public Guid Guid { get; set; } = Guid.NewGuid();

        public Guid CompanyGuid { get; set; }

        public Guid TeamGuid { get; set; }

        public Guid UserGuid { get; set; }
    }
}
