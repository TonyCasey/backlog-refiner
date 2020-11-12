using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tickets.Api.Business.Extensions;
using Tickets.Api.Core.Models.DTO.TicketMember;
using Tickets.Api.Core.Services;
using Tickets.Api.Data.Entities;
using Tickets.Api.Data.EntityFramework;

namespace Tickets.Api.Business.Services
{
    public class TicketMemberService : ITicketMemberService
    {
        private readonly ApplicationDbContext _dbContext;

        public TicketMemberService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TicketMember> Get(Guid guid)
        {
            return await _dbContext.TicketMembers.FirstOrDefaultAsync(x => x.Guid == guid && x.Deleted != true);
        }

        public async Task<TicketMember> Save(TicketMember record)
        {
            if (record.TicketMemberId <= 0)
            {
                await _dbContext.AddAsync(record);
            }
            else
            {
                _dbContext.Update(record);
            }

            await _dbContext.SaveChangesAsync();

            return record;
        }

        public IQueryable<TicketMember> Search(TicketMemberSearchModel searchModel, Guid companyGuid) =>
            _dbContext
                .TicketMembers
                .AsNoTracking()
                .NotDeleted()
                .ForCompany(companyGuid)
                .ForTicket(searchModel.TicketGuid)
                .ForTeamUser(searchModel.TeamUserGuid)
                .ForUser(searchModel.UserGuid)
                .AsQueryable();
    }
}
