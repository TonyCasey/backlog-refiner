using System;

namespace Sts.Core.Models.DTO.Team
{
    public class TeamSearchRequest
    {
        public Guid? TeamGuid { get; set; }

        public Guid? OwnerGuid { get; set; }
    }
}
