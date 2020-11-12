using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TestCases.Core.Models.DTO;
using TestCases.Data.Entities;

namespace TestCases.Core.Mappings
{
    public class TestCaseMapping : Profile
    {
        public TestCaseMapping()
        {
            CreateMap<TestCaseRequest, TestCase>()
                .ForMember(x => x.Guid, y => y.Ignore())
                .ForMember(x => x.CompanyGuid, y => y.Ignore())
                .ForMember(x => x.UserGuid, y => y.Ignore())
                //.ForMember(x => x.TicketGuid, y => y.Ignore())
                ;

            CreateMap<TestCase, TestCaseResponse>();
        }
    }
}
