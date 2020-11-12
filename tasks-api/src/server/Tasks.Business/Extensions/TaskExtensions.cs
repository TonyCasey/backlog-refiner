using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = Tasks.Data.Entities.Task;

namespace Tasks.Business.Extensions
{
    public static class TaskExtensions
    {
        public static IQueryable<Task> NotDeleted(this IQueryable<Task> records)
        {
            return records.Where(x => x.Deleted == null || x.Deleted == false);
        }

        public static IQueryable<Task> ForCompany(this IQueryable<Task> records, Guid companyGuid)
        {

            if (companyGuid == Guid.Empty)
                return records;

            return records.Where(x => x.CompanyGuid == companyGuid);
        }

        public static IQueryable<Task> ForBaord(this IQueryable<Task> records, Guid? guid)
        {

            if (guid == null)
                return records;

            return records.Where(x => x.BoardGuid == guid);
        }
        

        public static IQueryable<Task> ForTicket(this IQueryable<Task> records, Guid? guid)
        {

            if (guid == null)
                return records;

            return records.Where(x => x.TicketGuid == guid);
        }
    }
}
