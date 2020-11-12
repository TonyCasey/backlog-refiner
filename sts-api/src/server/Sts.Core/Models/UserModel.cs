using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sts.Data.Entities;

namespace Sts.Core.Models
{
    public class UserModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Guid CompanyGuid { get; set; }

        public string Avatar { get; set; }
    }
}
