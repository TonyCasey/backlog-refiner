using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Questions.Api.Data.Entities;

namespace Questions.Api.Business.Extensions
{
    public static class QuestionExtensions
    {
        public static IQueryable<Question> NotDeleted(this IQueryable<Question> questions)
        {
            return questions.Where(x => x.Deleted == null || x.Deleted == false);
        }

        public static IQueryable<Question> ForCompany(this IQueryable<Question> questions, Guid questionGuid)
        {

            if (questionGuid == Guid.Empty)
                return questions;

            return questions.Where(x => x.CompanyGuid == questionGuid);
        }

        public static IQueryable<Question> ForProject(this IQueryable<Question> questions, Guid projectGuid)
        {

            if (projectGuid == Guid.Empty)
                return questions;

            return questions.Where(x => x.ProjectGuid == projectGuid);
        }

        public static IQueryable<Question> ForUser(this IQueryable<Question> questions, Guid userGuid)
        {

            if (userGuid == Guid.Empty)
                return questions;

            return questions.Where(x => x.UserGuid == userGuid);
        }

        public static IQueryable<Question> ForTicket(this IQueryable<Question> questions, Guid ticketGuid)
        {

            if (ticketGuid == Guid.Empty)
                return questions;

            return questions.Where(x => x.TicketGuid == ticketGuid);
        }
    }
}
