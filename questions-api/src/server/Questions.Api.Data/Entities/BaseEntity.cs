using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using AutoMapper.Configuration;

namespace Questions.Api.Data.Entities
{
    public class BaseEntity
    {
        [Required]
        public DateTime CreationTime { get; set; }

        [Required]
        public Guid CreationUserGuid { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public Guid? LastUpdateUserGuid { get; set; }

        public bool? Deleted { get; set; }
    }
}
