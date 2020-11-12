using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Tickets.Api.Core.Models.DTO.Ticket;
using Tickets.Api.Core.Models.DTO.TicketMember;
using Tickets.Api.Data.Entities;

namespace Tickets.Api.Core.Mappings
{
    public class TicketMemberMapping : Profile
    {
        public TicketMemberMapping()
        {
            CreateMap<TicketMemberRequest, TicketMember>()
                .ForMember(x => x.Guid, y => y.Ignore())
                .ForMember(x => x.CompanyGuid, y => y.Ignore())
                ;

            CreateMap<TicketMember, TicketMemberResponse>();
        }
    }
}
