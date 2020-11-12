using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projects.Api.Data.Entities;

namespace Projects.Api.Business.Extensions
{
    public static class ProjectExtensions
    {
        public static IQueryable<Project> NotDeleted(this IQueryable<Project> records)
        {
            return records.Where(x => x.Deleted == null || x.Deleted == false);
        }

        public static IQueryable<Project> ForUser(this IQueryable<Project> records, Guid? guid)
        {
            if (guid == null || guid == Guid.Empty)
                return records;

            return records.Where(x => x.UserGuid == guid);
        }

        public static IQueryable<Project> ForProject(this IQueryable<Project> records, Guid? guid)
        {
            if (guid == null || guid == Guid.Empty)
                return records;

            return records.Where(x => x.Guid == guid);
        }

        public static IQueryable<Project> ForCompany(this IQueryable<Project> records, Guid guid)
        {
            if (guid == Guid.Empty)
                return records;

            return records.Where(x => x.CompanyGuid == guid);
        }

        public static IQueryable<Project> ForTeam(this IQueryable<Project> records, Guid? guid)
        {
            if (guid == null || guid == Guid.Empty)
                return records;

            return records.Where(x => x.TeamGuid == guid);
        }
    }
}
