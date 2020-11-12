using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Tasks.Core.Models.DTO;
using Tasks.Data.Entities;

namespace Tasks.Core.Mappings
{
    public class TaskMappings : Profile
    {
        public TaskMappings()
        {
            CreateMap<TaskRequest, Task>()
                .ForMember(x => x.Guid, y => y.Ignore())
                .ForMember(x => x.CompanyGuid, y => y.Ignore())
                .ForMember(x => x.UserGuid, y => y.Ignore())
                //.ForMember(x => x.TicketGuid, y => y.Ignore())
                ;

            CreateMap<Task, TaskResponse>();
        }
    }
}
