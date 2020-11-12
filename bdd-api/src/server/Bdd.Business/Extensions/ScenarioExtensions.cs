using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bdd.Data.Entities;

namespace Bdd.Business.Extensions
{
    public static class ScenarioExtensions
    {
        public static IQueryable<Scenario> NotDeleted(this IQueryable<Scenario> scenarios)
        {
            return scenarios.Where(x => x.Deleted == null || x.Deleted == false);
        }

        public static IQueryable<Scenario> ForCompany(this IQueryable<Scenario> scenarios, Guid companyGuid)
        {

            if (companyGuid == Guid.Empty)
                return scenarios;

            return scenarios.Where(x => x.CompanyGuid == companyGuid);
        }

        public static IQueryable<Scenario> ForBaord(this IQueryable<Scenario> scenarios, Guid? guid)
        {

            if (guid == null)
                return scenarios;

            return scenarios.Where(x => x.BoardGuid == guid);
        }

        public static IQueryable<Scenario> ForUser(this IQueryable<Scenario> scenarios, Guid? userGuid)
        {

            if (userGuid == null)
                return scenarios;

            return scenarios.Where(x => x.UserGuid == userGuid);
        }

        public static IQueryable<Scenario> ForTicket(this IQueryable<Scenario> scenarios, Guid ticketGuid)
        {

            if (ticketGuid == Guid.Empty)
                return scenarios;

            return scenarios.Where(x => x.TicketGuid == ticketGuid);
        }
    }
}
