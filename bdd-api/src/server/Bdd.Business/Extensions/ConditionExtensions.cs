using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bdd.Data.Entities;

namespace Bdd.Business.Extensions
{
    public static class ConditionExtensions
    {
        public static IQueryable<Condition> NotDeleted(this IQueryable<Condition> conditions)
        {
            return conditions.Where(x => x.Deleted == null || x.Deleted == false);
        }

        public static IQueryable<Condition> ForScenario(this IQueryable<Condition> conditions, Guid scenarioGuid)
        {

            if (scenarioGuid == Guid.Empty)
                return conditions;

            return conditions.Where(x => x.ScenarioGuid == scenarioGuid);
        }

        public static IQueryable<Condition> ForCondition(this IQueryable<Condition> conditions, Guid conditionGuid)
        {

            if (conditionGuid == Guid.Empty)
                return conditions;

            return conditions.Where(x => x.Guid == conditionGuid);
        }
    }
}
