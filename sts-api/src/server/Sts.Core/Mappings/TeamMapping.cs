using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sts.Core.Models.DTO.Team;
using Sts.Core.Models.DTO.TeamUser;
using Sts.Data.Entities;

namespace Sts.Core.Mappings
{
    public class TeamMapping : Profile
    {
        public TeamMapping()
        {
            CreateMap<TeamSearchRequest, Team>()
                .ForMember(x => x.Guid, y => y.Ignore())
                .ForMember(x => x.CompanyGuid, y => y.Ignore())
                .ForMember(x => x.OwnerGuid, y => y.Ignore())
                ;

            CreateMap<Team, TeamResponse>();
        }
    }
}
