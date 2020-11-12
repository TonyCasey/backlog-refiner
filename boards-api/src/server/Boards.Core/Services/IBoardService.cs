using Boards.Core.Models.DTO;
using Boards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boards.Core.Services
{
    public interface IBoardService
    {
        Task<Board> Get(Guid guid);

        Task<Board> Save(Board record);

        IQueryable<Board> Search(BoardSearchRequest searchRequest, Guid companyGuid);
    }
}
