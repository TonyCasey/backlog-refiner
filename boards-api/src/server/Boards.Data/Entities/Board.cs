using System;
using System.Collections.Generic;
using System.Text;

namespace Boards.Data.Entities
{
    public class Board : BaseEntity
    {

        public long BoardId { get; set; }

        public Guid UserGuid { get; set; }

        public Guid CompanyGuid { get; set; }

        public Guid TeamGuid { get; set; }

        public string Name { get; set; }
    }
}
