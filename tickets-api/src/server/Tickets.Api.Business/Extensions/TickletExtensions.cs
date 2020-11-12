using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tickets.Api.Core.Models.DTO;
using Tickets.Api.Data.Entities;

namespace Tickets.Api.Business.Extensions
{
    public static class TickletExtensions
    {
        public static IQueryable<Ticket> ForCompany(this IQueryable<Ticket> tickets, Guid companyGuid)
        {

            if (companyGuid == Guid.Empty)
                return new List<Ticket>().AsQueryable();

            return tickets.Where(x => x.CompanyGuid == companyGuid);
        }

        public static IQueryable<Ticket> ForBoard(this IQueryable<Ticket> tickets, Guid? guid)
        {
            if (guid == null)
                return tickets;

            return tickets.Where(x => x.BoardGuid == guid);
        }

        public static IQueryable<Ticket> ForUser(this IQueryable<Ticket> tickets, Guid? guid)
        {

            if (guid == null)
                return tickets;

            return tickets.Where(x => x.UserGuid == guid);
        }

        public static IQueryable<Ticket> ForTicket(this IQueryable<Ticket> tickets, Guid? guid)
        {

            if (guid == null)
                return tickets;

            return tickets.Where(x => x.Guid == guid);
        }

        public static IQueryable<Ticket> ForStatus(this IQueryable<Ticket> tickets, Guid? guid)
        {

            if (guid == null)
                return tickets;

            return tickets.Where(x => x.StatusGuid == guid);
        }

        public static IQueryable<Ticket> NotDeleted(this IQueryable<Ticket> tickets)
        {
            return tickets.Where(x => x.Deleted == null || x.Deleted == false);
        }
    }
}
