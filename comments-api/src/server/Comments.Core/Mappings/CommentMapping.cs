using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Comments.Core.DTO;
using Comments.Data.Entities;

namespace Comments.Core.Mappings
{
    public class CommentMapping : Profile
    {
        public CommentMapping()
        {
            CreateMap<CommentResponseModel, Comment>()
                .ForMember(x => x.Guid, y => y.Ignore())
                .ForMember(x => x.CompanyGuid, y => y.Ignore())
                .ForMember(x => x.UserGuid, y => y.Ignore())
                .ForMember(x => x.TicketGuid, y => y.Ignore())
                ;

            CreateMap<Comment, CommentResponseModel>();
        }
    }
}
