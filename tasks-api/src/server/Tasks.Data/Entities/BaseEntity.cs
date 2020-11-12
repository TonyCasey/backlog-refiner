using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tasks.Data.Entities
{
    public class BaseEntity
    {
        public Guid Guid { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime CreationTime { get; set; }

        [Required]
        public Guid CreationUserGuid { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public Guid? LastUpdateUserGuid { get; set; }

        public bool? Deleted { get; set; }
    }
}
