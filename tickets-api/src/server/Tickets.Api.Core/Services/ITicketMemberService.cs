using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Api.Core.Models.DTO;
using Tickets.Api.Core.Models.DTO.Ticket;
using Tickets.Api.Core.Models.DTO.TicketMember;
using Tickets.Api.Data.Entities;

namespace Tickets.Api.Core.Services
{
    public interface ITicketMemberService
    {
        Task<TicketMember> Get(Guid guid);

        Task<TicketMember> Save(TicketMember record);

        IQueryable<TicketMember> Search(TicketMemberSearchModel searchModel, Guid companyGuid);
    }
}
