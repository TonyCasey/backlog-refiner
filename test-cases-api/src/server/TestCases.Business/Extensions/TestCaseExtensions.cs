using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCases.Data.Entities;

namespace TestCases.Business.Extensions
{
    public static class TestCaseExtensions
    {
        public static IQueryable<TestCase> NotDeleted(this IQueryable<TestCase> records)
        {
            return records.Where(x => x.Deleted == null || x.Deleted == false);
        }

        public static IQueryable<TestCase> ForCompany(this IQueryable<TestCase> records, Guid companyGuid)
        {

            if (companyGuid == Guid.Empty)
                return records;

            return records.Where(x => x.CompanyGuid == companyGuid);
        }

        public static IQueryable<TestCase> ForBaord(this IQueryable<TestCase> records, Guid? guid)
        {

            if (guid == null)
                return records;

            return records.Where(x => x.BoardGuid == guid);
        }
        

        public static IQueryable<TestCase> ForTicket(this IQueryable<TestCase> records, Guid? guid)
        {

            if (guid == null)
                return records;

            return records.Where(x => x.TicketGuid == guid);
        }
    }
}
