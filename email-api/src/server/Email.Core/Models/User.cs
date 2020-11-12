using System;
using Microsoft.AspNetCore.Identity;

namespace Email.Core.Models
{
    public class User 
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Guid CompanyGuid { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

    }
}
