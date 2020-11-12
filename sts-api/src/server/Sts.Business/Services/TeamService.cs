using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sts.Business.Extensions;
using Sts.Core.Models.DTO;
using Sts.Core.Models.DTO.Team;
using Sts.Core.Services;
using Sts.Data.Entities;
using Sts.Data.EntityFramework;

namespace Sts.Business.Services
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _dbContext;

        public TeamService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Team> Get(Guid guid)
        {
            return await _dbContext.Teams.FirstOrDefaultAsync(x => x.Guid == guid && x.Deleted != true);
        }

        public async Task<Team> Save(Team record)
        {
            if (record.TeamId <= 0)
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

        public IQueryable<Team> Search(TeamSearchRequest searchRequest, Guid companyGuid) => _dbContext
            .Teams
            .AsNoTracking()
            .NotDeleted()
            .ForOwner(searchRequest.OwnerGuid)
            .ForCompany(companyGuid)
            .ForTeam(searchRequest.TeamGuid)
            .AsQueryable();
    }
}
