using System;
using System.Collections.Generic;
using System.Text;
using Projects.Api.Data.Entities;

namespace Projects.Api.Data.Seed
{
    public static class SeedProjects
    {
        public static List<Project> GetSeedProjects()
        {
            List<Project> records = new List<Project>()
            {
                new Project()
                {
                    CreationTime = DateTime.Now,
                    CreationUserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    Guid = Guid.NewGuid(),
                    CompanyGuid = new Guid("22e44764-3f21-471f-8f18-ae43d613c8cd"),
                    TeamGuid = new Guid("BE677A6E-A993-4AE3-9F11-82E4FC3B881F"),
                    UserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    Name = "BR Project 1"
                },
                new Project()
                {
                    CreationTime = DateTime.Now,
                    CreationUserGuid = new Guid("9922826F-8490-4C04-8F36-07115C6193B5"),
                    Guid = Guid.NewGuid(),
                    CompanyGuid = new Guid("3272D072-AC00-4D3A-8D3A-40A14D8D789D"),
                    TeamGuid = new Guid("A640AD1F-F981-4FCF-B126-81DB36AE3A24"),
                    UserGuid = new Guid("9922826F-8490-4C04-8F36-07115C6193B5"),
                    Name = "RE Project 1"
                }
            };


            int index = 1;
            foreach (var record in records)
            {
                record.ProjectId = index;
                ++index;
            }

            return records;
        }
    }
}
