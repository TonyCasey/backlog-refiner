﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Notifications.Data.Entities
{
    public class BaseEntity
    {
        public Guid Guid { get; set; } = Guid.NewGuid();

        public DateTime CreationTime { get; set; }

        public Guid CreationUserGuid { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public Guid? LastUpdateUserGuid { get; set; }

        public bool? Deleted { get; set; }
    }
}
