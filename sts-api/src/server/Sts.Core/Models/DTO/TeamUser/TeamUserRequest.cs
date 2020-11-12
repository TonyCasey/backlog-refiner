using System;

namespace Sts.Core.Models.DTO.TeamUser
{
    public class TeamUserRequest
    {
        public Guid UserGuid { get; set; }

        public Guid TeamGuid { get; set; }
    }
}
