using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bdd.Business.Extensions;
using Bdd.Core.Models.DTO;
using Bdd.Core.Services;
using Bdd.Data.Entities;
using Bdd.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Bdd.Business.Services
{
    public class ScenarioService : IScenarioService
    {
        private readonly ApplicationDbContext _dbContext;

        public ScenarioService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Scenario> Get(Guid guid)
        {
            return await _dbContext.Scenarios.FirstOrDefaultAsync(x => x.Guid == guid && x.Deleted != true);
        }

        public async Task<Scenario> Save(Scenario record)
        {
            if (record.ScenarioId <= 0)
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

        public IQueryable<Scenario> Search(ScenarioSearchRequest searchRequest, Guid companyGuid) => _dbContext
            .Scenarios
            .AsNoTracking()
            .NotDeleted()
            .ForUser(searchRequest.UserGuid)
            .ForCompany(companyGuid)
            .ForBaord(searchRequest.BoardGuid)
            .ForTicket(searchRequest.TicketGuid)
            .AsQueryable();
    }
}
