using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comments.Business.Extensions;
using Comments.Core.DTO;
using Comments.Core.Services;
using Comments.Data.Entities;
using Comments.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Comments.Business.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> Get(Guid commentGuid)
        {
            return await _dbContext.Comments.FirstOrDefaultAsync(x => x.Guid == commentGuid && (x.Deleted == null || x.Deleted == false ) ) ;
        }

        public async Task<Comment> Save(Comment comment)
        {
            if (comment.CommentId <= 0)
            {
                await _dbContext.AddAsync(comment);
            }
            else
            {
                _dbContext.Update(comment);
            }

            await _dbContext.SaveChangesAsync();

            return comment;
        }

        public IQueryable<Comment> Search(SearchModel searchModel, Guid companyGuid)
        {
            return
                _dbContext
                    .Comments
                    .AsNoTracking()
                    .NotDeleted()
                    .ForUser(searchModel.UserGuid)
                    .ForCompany(companyGuid)
                    .ForComment(searchModel.CommentGuid)
                    .ForQuestion(searchModel.QuestionGuid)
                    .ForTicket(searchModel.TicketGuid)
                ;
        }
    }
}
