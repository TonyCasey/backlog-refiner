using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration;

namespace Sts.Data.Entities
{
    public class BaseEntity
    {
        public DateTime CreationTime { get; set; }

        public Guid CreationUserGuid { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public Guid? LastUpdateUserGuid { get; set; }

        public bool? Deleted { get; set; }
    }
}
