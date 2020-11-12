using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sts.Core.Models.DTO;
using Sts.Core.Models.DTO.TeamUser;
using Sts.Data.Entities;

namespace Sts.Core.Mappings
{
    public class TeamUserMapping : Profile
    {
        public TeamUserMapping()
        {
            CreateMap<TeamUserSearchRequest, TeamUser>()
                .ForMember(x => x.Guid, y => y.Ignore())
                .ForMember(x => x.CompanyGuid, y => y.Ignore())
                ;

            CreateMap<TeamUser, TeamUserResponse>();
        }
    }
}
