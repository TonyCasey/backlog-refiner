using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Api.Core.Models.DTO;
using Tickets.Api.Core.Models.DTO.Ticket;
using Tickets.Api.Data.Entities;

namespace Tickets.Api.Core.Services
{
    public interface ITicketService
    {
        Task<Ticket> Get(Guid guid);

        Task<Ticket> Save(Ticket ticket);

        IQueryable<Ticket> Search(SearchModel searchModel, Guid companyGuid);

    }
}
