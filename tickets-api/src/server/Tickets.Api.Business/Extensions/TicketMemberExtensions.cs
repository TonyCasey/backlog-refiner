using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tickets.Api.Data.Entities;

namespace Tickets.Api.Business.Extensions
{
    public static class TicketMemberExtensions
    {
        public static IQueryable<TicketMember> NotDeleted(this IQueryable<TicketMember> records)
        {
            return records.Where(x => x.Deleted == null || x.Deleted == false);
        }

        public static IQueryable<TicketMember> ForCompany(this IQueryable<TicketMember> records, Guid companyGuid)
        {

            if (companyGuid == Guid.Empty)
                return new List<TicketMember>().AsQueryable();

            return records.Where(x => x.CompanyGuid == companyGuid);
        }

        public static IQueryable<TicketMember> ForTicket(this IQueryable<TicketMember> tickets, Guid? guid)
        {

            if (guid == null)
                return tickets;

            return tickets.Where(x => x.TicketGuid == guid);
        }

        public static IQueryable<TicketMember> ForTeamUser(this IQueryable<TicketMember> tickets, Guid? guid)
        {

            if (guid == null)
                return tickets;

            return tickets.Where(x => x.TeamUserGuid == guid);
        }

        public static IQueryable<TicketMember> ForUser(this IQueryable<TicketMember> tickets, Guid? guid)
        {

            if (guid == null)
                return tickets;

            return tickets.Where(x => x.UserGuid == guid);
        }
    }
}
