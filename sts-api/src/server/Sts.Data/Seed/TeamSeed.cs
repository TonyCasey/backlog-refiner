using System;
using System.Collections.Generic;
using System.Text;
using Sts.Data.Entities;

namespace Sts.Data.Seed
{
    public static class TeamSeed
    {
        public static List<Team> GetSeedTeams()
        {
            List<Team> records = new List<Team>()
            {
                new Team()
                {
                    Guid = new Guid("BE677A6E-A993-4AE3-9F11-82E4FC3B881F"),
                    CompanyGuid = new Guid("22e44764-3f21-471f-8f18-ae43d613c8cd"),
                    CreationUserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    OwnerGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    Name = "Team 1",
                    CreationTime = DateTime.Now
                },
                new Team()
                {
                    Guid = new Guid("A640AD1F-F981-4FCF-B126-81DB36AE3A24"),
                    CompanyGuid = new Guid("3272D072-AC00-4D3A-8D3A-40A14D8D789D"),
                    CreationUserGuid = new Guid("9922826F-8490-4C04-8F36-07115C6193B5"),
                    OwnerGuid = new Guid("9922826F-8490-4C04-8F36-07115C6193B5"),
                    Name = "Team 2",
                    CreationTime = DateTime.Now
                }
            };




            int index = 1;
            foreach (var record in records)
            {
                record.TeamId = index;
                ++index;
            }

            return records;

        }
    }
}
