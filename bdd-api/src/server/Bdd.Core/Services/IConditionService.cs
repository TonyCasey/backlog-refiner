using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bdd.Core.Models.DTO;
using Bdd.Data.Entities;

namespace Bdd.Core.Services
{
    public interface IConditionService
    {
        Task<Condition> Get(Guid guid);

        Task<Condition> Save(Condition record);

        IQueryable<Condition> Search(ConditionSearchRequest searchRequest, Guid companyGuid);
    }
}
