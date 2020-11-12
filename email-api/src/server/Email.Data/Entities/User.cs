using System;
using System.Collections.Generic;
using System.Text;

namespace Email.Data.Entities
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
