using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comments.Data.Entities;

namespace Comments.Business.Extensions
{
    public static class CommentsExtensions
    {
        public static IQueryable<Comment> NotDeleted(this IQueryable<Comment> comments)
        {
            return comments.Where(x => x.Deleted == null || x.Deleted == false);
        }

        public static IQueryable<Comment> ForCompany(this IQueryable<Comment> comments, Guid companyGuid)
        {

            if (companyGuid == Guid.Empty)
                return comments;

            return comments.Where(x => x.CompanyGuid == companyGuid);
        }
        
        public static IQueryable<Comment> ForUser(this IQueryable<Comment> comments, Guid userGuid)
        {

            if (userGuid == Guid.Empty)
                return comments;

            return comments.Where(x => x.UserGuid == userGuid);
        }

        public static IQueryable<Comment> ForComment(this IQueryable<Comment> comments, Guid commentGuid)
        {

            if (commentGuid == Guid.Empty)
                return comments;

            return comments.Where(x => x.Guid == commentGuid);
        }

        public static IQueryable<Comment> ForTicket(this IQueryable<Comment> comments, Guid ticketGuid)
        {

            if (ticketGuid == Guid.Empty)
                return comments;

            return comments.Where(x => x.TicketGuid == ticketGuid);
        }

        public static IQueryable<Comment> ForQuestion(this IQueryable<Comment> comments, Guid questiontGuid)
        {

            if (questiontGuid == Guid.Empty)
                return comments;

            return comments.Where(x => x.QuestionGuid == questiontGuid);
        }
    }
}
