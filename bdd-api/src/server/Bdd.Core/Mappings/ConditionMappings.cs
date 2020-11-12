using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bdd.Core.Models.DTO;
using Bdd.Data.Entities;

namespace Bdd.Core.Mappings
{
    public class ConditionMappings : Profile
    {
        public ConditionMappings()
        {
            CreateMap<ConditionRequest, Condition>()
                .ForMember(x => x.Guid, y => y.Ignore())
                .ForMember(x => x.CompanyGuid, y => y.Ignore())
                .ForMember(x => x.UserGuid, y => y.Ignore())
                .ForMember(x => x.ScenarioGuid, y => y.Ignore())
                .AfterMap((src, dst) =>
                {
                    if (src.ScenarioGuid != Guid.Empty)
                        dst.ScenarioGuid = src.ScenarioGuid;

                });
                ;

            CreateMap<Condition, ConditionResponse>();
        }
    }
}
