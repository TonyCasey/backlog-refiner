using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Bdd.Core.Models.DTO;
using Bdd.Data.Entities;

namespace Bdd.Core.Mappings
{
    public class ScenarioMappings : Profile
    {
        public ScenarioMappings()
        {
            CreateMap<ScenarioRequest, Scenario>()
                .ForMember(x => x.Guid, y => y.Ignore())
                .ForMember(x => x.CompanyGuid, y => y.Ignore())
                .ForMember(x => x.UserGuid, y => y.Ignore())
                ;

            CreateMap<Scenario, ScenarioResponse>();
        }
    }
}
