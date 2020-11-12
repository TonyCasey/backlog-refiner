using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Email.Core.Models.DTO;

namespace Email.Core.Mappings
{
    public class EmailMappings : Profile
    {
        public EmailMappings()
        {
            CreateMap<EmailRequest, Data.Entities.Email>()
                .ForMember(x => x.Guid, y => y.Ignore())
                .ForMember(x => x.CompanyGuid, y => y.Ignore())
                ;

            CreateMap<Data.Entities.Email, EmailResponse>();
        }
    }
}
