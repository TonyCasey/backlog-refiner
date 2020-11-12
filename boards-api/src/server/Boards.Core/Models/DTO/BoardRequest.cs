using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Boards.Core.Models.DTO
{
    public class BoardRequest
    {
        [Required]
        public Guid? TeamGuid { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
