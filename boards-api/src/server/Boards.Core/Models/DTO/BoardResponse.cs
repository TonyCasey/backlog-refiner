using System;
using System.Collections.Generic;
using System.Text;

namespace Boards.Core.Models.DTO
{
    public class BoardResponse
    {
        public Guid Guid { get; set; }

        public Guid UserGuid { get; set; }

        public Guid TeamGuid { get; set; }

        public string Name { get; set; }
    }
}
