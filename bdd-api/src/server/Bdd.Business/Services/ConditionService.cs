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
    public class ConditionService : IConditionService
    {
        private readonly ApplicationDbContext _dbContext;

        public ConditionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Condition> Get(Guid guid)
        {
            return await _dbContext.Conditions.FirstOrDefaultAsync(x => x.Guid == guid && x.Deleted != true);
        }

        public async Task<Condition> Save(Condition record)
        {
            if (record.ConditionId <= 0)
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

        public IQueryable<Condition> Search(ConditionSearchRequest searchRequest, Guid companyGuid) => _dbContext
            .Conditions
            .AsNoTracking()
            .NotDeleted()
            .ForScenario(searchRequest.ScenarioGuid)
            //.ForCondition(searchRequest)
            .OrderBy(x => x.ConditionId )
            .AsQueryable();
    }
}
