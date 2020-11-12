using System;
using System.Collections.Generic;
using System.Text;
using Sts.Data.Entities;

namespace Sts.Data.Seed
{
    public static class TeamUsersSeed
    {
        public static List<TeamUser> GetSeedTeamUsers()
        {
            List<TeamUser> records = new List<TeamUser>()
            {
                new TeamUser()
                {
                    CreationTime = DateTime.Now,
                    Guid = new Guid("7CDFC900-2C23-45F0-A18D-1D930238BCCB"),
                    CompanyGuid = new Guid("22e44764-3f21-471f-8f18-ae43d613c8cd"),
                    CreationUserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff"),
                    TeamGuid = new Guid("BE677A6E-A993-4AE3-9F11-82E4FC3B881F"),
                    UserGuid = new Guid("d3a9dece-b96d-457c-8b86-273b72e37cff")
                },
                new TeamUser()
                {
                    CreationTime = DateTime.Now,
                    Guid = new Guid("DF601B90-302A-417C-AD32-F6C6C7269838"),
                    CompanyGuid = new Guid("3272D072-AC00-4D3A-8D3A-40A14D8D789D"),
                    CreationUserGuid = new Guid("9922826F-8490-4C04-8F36-07115C6193B5"),
                    TeamGuid = new Guid("A640AD1F-F981-4FCF-B126-81DB36AE3A24"),
                    UserGuid = new Guid("9922826F-8490-4C04-8F36-07115C6193B5")
                }
            };


            int index = 1;
            foreach (var record in records)
            {
                record.TeamUserId = index;
                ++index;
            }

            return records;

        }
    }
}
