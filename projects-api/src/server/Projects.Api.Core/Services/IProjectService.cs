using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.Api.Core.Models.DTO;
using Projects.Api.Data.Entities;

namespace Projects.Api.Core.Services
{
    public interface IProjectService
    {
        Task<Project> Get(Guid guid);

        Task<Project> Save(Project record);

        IQueryable<Project> Search(ProjectSearchRequest searchRequest, Guid companyGuid);
    }
}
