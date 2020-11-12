using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boards.Data.Entities;

namespace Boards.Business.Extensions
{
    public static class BoardExtensions
    {
        public static IQueryable<Board> NotDeleted(this IQueryable<Board> boards)
        {
            return boards.Where(x => x.Deleted == null || x.Deleted == false);
        }

        public static IQueryable<Board> ForTeam(this IQueryable<Board> boards, Guid guid)
        {

            if (guid == Guid.Empty)
                return boards;

            return boards.Where(x => x.TeamGuid == guid);
        }

        public static IQueryable<Board> ForBoard(this IQueryable<Board> boards, Guid guid)
        {

            if (guid == Guid.Empty)
                return boards;

            return boards.Where(x => x.Guid == guid);
        }
        
        public static IQueryable<Board> ForCompany(this IQueryable<Board> boards, Guid guid)
        {

            if (guid == Guid.Empty)
                return boards;

            return boards.Where(x => x.CompanyGuid == guid);
        }
    }
}
