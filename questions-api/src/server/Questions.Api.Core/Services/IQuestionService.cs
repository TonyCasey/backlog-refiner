using Questions.Api.Core.Models.DTO;
using Questions.Api.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Questions.Api.Core.Services
{
    public interface IQuestionService
    {
        Task<Question> Get(Guid commentGuid);

        Task<Question> Save(Question question);

        IQueryable<Question> Search(SearchRequest searchRequest, Guid questionGuid);
    }
}
