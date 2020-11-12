using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Projects.Api.Core.Models.DTO;
using Projects.Api.Data.Entities;

namespace Projects.Api.Core.Mappings
{
    public class ProjectMapping : Profile
    {
        public ProjectMapping()
        {
            CreateMap<ProjectRequest, Project>()
                .ForMember(x => x.Guid, y => y.Ignore())
                .ForMember(x => x.CompanyGuid, y => y.Ignore())
                .ForMember(x => x.UserGuid, y => y.Ignore())
                .AfterMap((src, dst) =>
                {
                    if (src.TeamGuid != null && src.TeamGuid != Guid.Empty)
                        dst.TeamGuid = (Guid)src.TeamGuid;

                });
            ;

            CreateMap<Project, ProjectResponse>();
        }
    }
}
