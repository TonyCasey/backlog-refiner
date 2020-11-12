using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sts.Data.Entities;

namespace Sts.Business.Extensions
{
    public static class TeamExtensions
    {
        public static IQueryable<Team> NotDeleted(this IQueryable<Team> teams)
        {
            return teams.Where(x => x.Deleted == null || x.Deleted == false);
        }

        public static IQueryable<Team> ForCompany(this IQueryable<Team> teams, Guid guid)
        {

            if (guid == Guid.Empty)
                return teams;

            return teams.Where(x => x.CompanyGuid == guid);
        }

        public static IQueryable<Team> ForTeam(this IQueryable<Team> teams, Guid? guid)
        {

            if (guid == null || guid == Guid.Empty)
                return teams;

            return teams.Where(x => x.Guid == guid);
        }

        public static IQueryable<Team> ForOwner(this IQueryable<Team> teams, Guid? guid)
        {

            if (guid == null || guid == Guid.Empty)
                return teams;

            return teams.Where(x => x.OwnerGuid == guid);
        }
    }
}
