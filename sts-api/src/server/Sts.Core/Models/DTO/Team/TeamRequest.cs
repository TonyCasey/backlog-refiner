using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sts.Core.Models.DTO.Team
{
    public class TeamRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
