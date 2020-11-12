using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Tickets.Api.Core.Models.DTO;
using Tickets.Api.Core.Models.DTO.Ticket;
using Tickets.Api.Data.Entities;

namespace Tickets.Api.Core.Mappings
{
    public class TicketMapping : Profile
    {

        public TicketMapping()
        {
            CreateMap<TicketRequestModel, Ticket>()
                .ForMember(x => x.Guid, y => y.Ignore())
                .ForMember(x => x.CompanyGuid, y => y.Ignore())
                .ForMember(x => x.UserGuid, y => y.Ignore())
                ;

            CreateMap<Ticket, TicketResponseModel>();
        }
    }
}
