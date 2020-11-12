using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Email.Business.Extensions
{
    public static class EmailExtensions
    {
        public static IQueryable<Data.Entities.Email> NotDeleted(this IQueryable<Data.Entities.Email> records)
        {
            return records.Where(x => x.Deleted == null || x.Deleted == false);
        }

        public static IQueryable<Data.Entities.Email> ForCompany(this IQueryable<Data.Entities.Email> records, Guid companyGuid)
        {

            if (companyGuid == Guid.Empty)
                return new List<Data.Entities.Email>().AsQueryable();

            return records.Where(x => x.CompanyGuid == companyGuid);
        }

        public static IQueryable<Data.Entities.Email> ForTicket(this IQueryable<Data.Entities.Email> records, Guid? guid)
        {

            if (guid == null)
                return records;

            return records.Where(x => x.TicketGuid == guid);
        }

        public static IQueryable<Data.Entities.Email> ForNotification(this IQueryable<Data.Entities.Email> records, Guid? guid)
        {

            if (guid == null)
                return records;

            return records.Where(x => x.NotificationGuid == guid);
        }

      public static IQueryable<Data.Entities.Email> ToUser(this IQueryable<Data.Entities.Email> records, Guid? guid)
        {

            if (guid == null)
                return records;

            return records.Where(x => x.ToUserGuid == guid);
        }
    }
}
