using System;
using System.ComponentModel.DataAnnotations;

namespace Sts.Core.Models.DTO.TeamUser
{
    public class TeamUserSearchRequest
    {
        public Guid? UserGuid { get; set; }

        [Required]
        public Guid? TeamGuid { get; set; }

    }
}
