using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sts.Core.Models.DTO;
using Sts.Core.Models.DTO.TeamUser;
using Sts.Data.Entities;

namespace Sts.Core.Services
{
    public interface ITeamUserService
    {
        Task<TeamUser> Get(Guid guid);

        Task<TeamUser> Save(TeamUser record);

        IQueryable<TeamUser> Search(TeamUserSearchRequest searchRequest, Guid companyGuid);
    }
}
