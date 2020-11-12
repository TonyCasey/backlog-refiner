using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Questions.Api.Core.Models.DTO;
using Questions.Api.Data.Entities;

namespace Questions.Api.Core.Mappings
{
    public class QuestionMapping : Profile
    {
        public QuestionMapping()
        {
            CreateMap<QuestionRequest, Question>()
                .ForMember(x => x.Guid, y => y.Ignore())
                .ForMember(x => x.CompanyGuid, y => y.Ignore())
                .ForMember(x => x.UserGuid, y => y.Ignore())
                ;

            CreateMap<Question, QuestionResponse>();
        }
    }
}
