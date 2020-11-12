using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sts.Data.Entities;

namespace Sts.Business.Extensions
{
    public static class TeamUserExtensions
    {
        public static IQueryable<TeamUser> NotDeleted(this IQueryable<TeamUser> teamUsers)
        {
            return teamUsers.Where(x => x.Deleted == null || x.Deleted == false);
        }

        public static IQueryable<TeamUser> ForCompany(this IQueryable<TeamUser> teamUsers, Guid guid)
        {

            if (guid == Guid.Empty)
                return teamUsers;

            return teamUsers.Where(x => x.CompanyGuid == guid);
        }

        public static IQueryable<TeamUser> ForTeam(this IQueryable<TeamUser> teamUsers, Guid? guid)
        {

            if (guid == null || guid == Guid.Empty)
                return teamUsers;

            return teamUsers.Where(x => x.TeamGuid == guid);
        }

        public static IQueryable<TeamUser> ForUser(this IQueryable<TeamUser> teamUsers, Guid? guid)
        {

            if (guid == null || guid == Guid.Empty)
                return teamUsers;

            return teamUsers.Where(x => x.UserGuid == guid);
        }
    }
}
