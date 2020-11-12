using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projects.Api.Business.Extensions;
using Projects.Api.Core.Models.DTO;
using Projects.Api.Core.Services;
using Projects.Api.Data.Entities;
using Projects.Api.Data.EntityFramework;

namespace Projects.Api.Business.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProjectService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Project> Get(Guid guid)
        {
            return await _dbContext.Projects.FirstOrDefaultAsync(x => x.Guid == guid && x.Deleted != true);
        }

        public async Task<Project> Save(Project record)
        {
            if (record.ProjectId <= 0)
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

        public IQueryable<Project> Search(ProjectSearchRequest searchRequest, Guid companyGuid) =>
            _dbContext
                .Projects
                .AsNoTracking()
                .NotDeleted()
                .ForUser(searchRequest.UserGuid)
                .ForCompany(companyGuid)
                .ForProject(searchRequest.ProjectGuid)
                .AsQueryable();
    }
}
