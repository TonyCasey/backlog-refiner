using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sts.Core.Models.DTO;
using Sts.Core.Models.DTO.Team;
using Sts.Data.Entities;

namespace Sts.Core.Services
{
    public interface ITeamService
    {
        Task<Team> Get(Guid guid);

        Task<Team> Save(Team Team);

        IQueryable<Team> Search(TeamSearchRequest searchModel, Guid companyGuid);
    }
}
