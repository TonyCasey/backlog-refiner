using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comments.Core.DTO;
using Comments.Data.Entities;

namespace Comments.Core.Services
{
    public interface ICommentService
    {
        Task<Comment> Get(Guid commentGuid);

        Task<Comment> Save(Comment comment);

        IQueryable<Comment> Search(SearchModel searchModel, Guid companyGuid);

    }
}
