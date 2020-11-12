using System;
using System.Collections.Generic;
using System.Text;

namespace Boards.Core.Models.DTO
{
    public class BoardSearchRequest
    {
        public Guid Guid { get; set; }

        public Guid TeamGuid { get; set; }
    }
}
