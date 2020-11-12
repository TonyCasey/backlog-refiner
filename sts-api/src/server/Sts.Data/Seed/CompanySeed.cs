using System;
using System.Collections.Generic;
using System.Text;
using Sts.Data.Entities;

namespace Sts.Data.Seed
{
    public static class CompanySeed
    {
        public static List<Company> GetSeedCompanies()
        {
            List<Company> records = new List<Company>()
            {
                new Company()
                {
                    CreationTime = DateTime.Now,
                    CreationUserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    Guid = new Guid("22e44764-3f21-471f-8f18-ae43d613c8cd"),
                    Name = "Backlog Refiner",
                    DomainName = "backlogrefiner.com"
                },
                new Company()
                {
                    CreationTime = DateTime.Now,
                    CreationUserGuid = new Guid("9922826F-8490-4C04-8F36-07115C6193B5"),
                    Guid = new Guid("3272D072-AC00-4D3A-8D3A-40A14D8D789D"),
                    Name = "ACME Corp",
                    DomainName = "acme.com"
                }
            };




            int index = 1;
            foreach (var record in records)
            {
                record.CompanyId = index;
                ++index;
            }

            return records;

        }
    }
}
