using System;
using System.Collections.Generic;
using System.Text;
using Sts.Data.Entities;

namespace Sts.Data.Seed
{
    public static class UserSeed
    {

        public static List<User> GetSeedUsers()
        {
            List<User> records = new List<User>()
            {
                new User()
                {
                    Id = "d3a9dece-b96d-457c-8b86-273b72e37cff",
                    UserName = "test1@backlogrefiner.com",
                    NormalizedUserName = "TEST1@BACKLOGREFINER.COM",
                    Email = "test1@backlogrefiner.com",
                    NormalizedEmail = "TEST1@BACKLOGREFINER.COM",
                    EmailConfirmed = false,
                    PasswordHash = "[TODO]",
                    SecurityStamp = "[TODO]",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    FirstName = "Test",
                    LastName = "One",
                    RegistrationDate = DateTime.Now,
                    CompanyGuid = new Guid("22e44764-3f21-471f-8f18-ae43d613c8cd")
                },

                new User()
                {
                    Id = "9922826F-8490-4C04-8F36-07115C6193B5",
                    UserName = "test2@backlogrefiner.com",
                    NormalizedUserName = "TEST2@BACKLOGREFINER.COM",
                    Email = "test2@backlogrefiner.com",
                    NormalizedEmail = "TEST2@BACKLOGREFINER.COM",
                    EmailConfirmed = false,
                    PasswordHash = "[TODO]",
                    SecurityStamp = "[TODO]",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    FirstName = "Test",
                    LastName = "Two",
                    RegistrationDate = DateTime.Now,
                    CompanyGuid = new Guid("3272D072-AC00-4D3A-8D3A-40A14D8D789D")
                },
                
            };




            return records;

        }
    }
}
