using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tickets.Api.Business.Extensions;
using Tickets.Api.Core.Models.DTO;
using Tickets.Api.Core.Models.DTO.Ticket;
using Tickets.Api.Core.Services;
using Tickets.Api.Data.Entities;
using Tickets.Api.Data.EntityFramework;

namespace Tickets.Api.Business.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _dbContext;

        public TicketService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Ticket> Get(Guid guid)
        {
            return await _dbContext.Tickets.FirstOrDefaultAsync(x => x.Guid == guid && x.Deleted != true);
        }

        public async Task<Ticket> Save(Ticket ticket)
        {
            if (ticket.TicketId <= 0)
            {
                await _dbContext.AddAsync(ticket);
            }
            else
            {
                _dbContext.Update(ticket);
            }

            await _dbContext.SaveChangesAsync();

            return ticket;
        }

        public IQueryable<Ticket> Search(SearchModel searchModel, Guid companyGuid) =>
                _dbContext
                    .Tickets
                    .AsNoTracking()
                    .NotDeleted()
                    .ForUser(searchModel.UserGuid)
                    .ForCompany(companyGuid)
                    .ForBoard(searchModel.BoardGuid)
                    .ForStatus(searchModel.StatusGuid)
                    .AsQueryable();
    }
}
