using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Tasks.Business.Extensions;
using Tasks.Core.Models.DTO;
using Tasks.Core.Services;
using Tasks.Data.Entities;
using Tasks.Data.EntityFramework;
using Task = Tasks.Data.Entities.Task;

namespace Tasks.Business.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async System.Threading.Tasks.Task<Task> Get(Guid guid)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Guid == guid && x.Deleted != true);
        }

        public async System.Threading.Tasks.Task<Task> Save(Task record)
        {
            if (record.TaskId <= 0)
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

        public IQueryable<Task> Search(TaskSearchRequest searchRequest, Guid companyGuid) => _dbContext
            .Tasks
            .AsNoTracking()
            .NotDeleted()
            .ForCompany(companyGuid)
            .ForBaord(searchRequest.BoardGuid)
            .ForTicket(searchRequest.TicketGuid)
            .AsQueryable();
    }
}
