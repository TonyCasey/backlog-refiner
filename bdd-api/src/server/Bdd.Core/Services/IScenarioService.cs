using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bdd.Core.Models.DTO;
using Bdd.Data.Entities;

namespace Bdd.Core.Services
{
    public interface IScenarioService
    {
        Task<Scenario> Get(Guid guid);

        Task<Scenario> Save(Scenario record);

        IQueryable<Scenario> Search(ScenarioSearchRequest searchRequest, Guid companyGuid);
    }
}
