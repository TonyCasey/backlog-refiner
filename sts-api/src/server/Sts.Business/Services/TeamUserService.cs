using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sts.Business.Extensions;
using Sts.Core.Models.DTO;
using Sts.Core.Models.DTO.TeamUser;
using Sts.Core.Services;
using Sts.Data.Entities;
using Sts.Data.EntityFramework;

namespace Sts.Business.Services
{
    public class TeamUserService : ITeamUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public TeamUserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<TeamUser> Get(Guid guid)
        {
            return await _dbContext.TeamUsers.FirstOrDefaultAsync(x => x.Guid == guid && x.Deleted != true);
        }

        public async Task<TeamUser> Save(TeamUser record)
        {
            if (record.TeamUserId <= 0)
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

        public IQueryable<TeamUser> Search(TeamUserSearchRequest searchRequest, Guid companyGuid) => _dbContext
            .TeamUsers
            .AsNoTracking()
            .NotDeleted()
            .ForCompany(companyGuid)
            //.ForUser(searchRequest.UserGuid)
            .ForTeam(searchRequest.TeamGuid)
            .AsQueryable();
    }
}
