using System;
using Microsoft.AspNetCore.Identity;

namespace Sts.Data.Entities
{
    public class User : IdentityUser<string>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Guid CompanyGuid { get; set; }

        public string Avatar { get; set; }

    }
}
