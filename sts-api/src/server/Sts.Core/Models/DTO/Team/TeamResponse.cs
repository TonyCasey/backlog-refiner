using System;
using System.Collections.Generic;
using System.Text;

namespace Sts.Core.Models.DTO.Team
{
    public class TeamResponse
    {
        public Guid Guid { get; set; }
        
        public DateTime CreationTime { get; set; }

        public string Name { get; set; }
    }
}
