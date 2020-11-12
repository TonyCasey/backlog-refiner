using System;

namespace Sts.Core.Models.DTO.TeamUser
{
    public class TeamUserResponse
    {
        public Guid Guid { get; set; }

        public Guid UserGuid { get; set; }

        public Guid TeamGuid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Avatar { get; set; }
    }
}
