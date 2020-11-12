using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Questions.Api.Business.Extensions;
using Questions.Api.Core.Models.DTO;
using Questions.Api.Core.Services;
using Questions.Api.Data.Entities;
using Questions.Api.Data.EntityFramework;

namespace Questions.Api.Business.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _dbContext;

        public QuestionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Question> Get(Guid commentGuid)
        {
            return await _dbContext.Questions.FirstOrDefaultAsync(x => x.Guid == commentGuid && x.Deleted != true);
        }

        public async Task<Question> Save(Question question)
        {
            if (question.QuestionId <= 0)
            {
                await _dbContext.AddAsync(question);
            }
            else
            {
                _dbContext.Update(question);
            }

            await _dbContext.SaveChangesAsync();

            return question;
        }

        IQueryable<Question> IQuestionService.Search(SearchRequest searchRequest, Guid companyGuid) => _dbContext
            .Questions
            .AsNoTracking()
            .NotDeleted()
            .ForUser(searchRequest.UserGuid)
            .ForCompany(companyGuid)
            .ForProject(searchRequest.ProjectGuid)
            .ForTicket(searchRequest.TicketGuid)
            .AsQueryable();
    }
}
