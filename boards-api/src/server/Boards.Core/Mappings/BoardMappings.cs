using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Boards.Core.Models.DTO;
using Boards.Data.Entities;

namespace Boards.Core.Mappings
{
    public class BoardMappings : Profile

    {
        public BoardMappings()
        {
            CreateMap<BoardRequest, Board>()
                .ForMember(x => x.Guid, y => y.Ignore())
                .ForMember(x => x.CompanyGuid, y => y.Ignore())
                .ForMember(x => x.UserGuid, y => y.Ignore())
                .AfterMap((src, dst) =>
                {
                    if (src.TeamGuid != null && src.TeamGuid != Guid.Empty)
                        dst.TeamGuid = (Guid)src.TeamGuid;

                });
            ;

            CreateMap<Board, BoardResponse>();
        }
    }
}
