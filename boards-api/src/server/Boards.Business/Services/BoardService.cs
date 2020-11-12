using Boards.Core.Models.DTO;
using Boards.Core.Services;
using Boards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boards.Business.Extensions;
using Boards.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Boards.Business.Services
{
    public class BoardService : IBoardService
    {
        private readonly ApplicationDbContext _dbContext;

        public BoardService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Board> Get(Guid guid)
        {
            return await _dbContext.Boards.FirstOrDefaultAsync(x => x.Guid == guid && x.Deleted != true);
        }

        public async Task<Board> Save(Board record)
        {
            if (record.BoardId <= 0)
            {
                await _dbContext.AddAsync(record);
            }
            else
            {
                _dbContext.Update(record);
            }

            await _dbContext.SaveChangesAsync();

            return record;
        }

        public IQueryable<Board> Search(BoardSearchRequest searchRequest, Guid companyGuid) => _dbContext
            .Boards
            .AsNoTracking()
            .NotDeleted()
            .ForCompany(companyGuid)
            .ForBoard(searchRequest.Guid)
            .ForTeam(searchRequest.TeamGuid)
            .AsQueryable();
    }
}
