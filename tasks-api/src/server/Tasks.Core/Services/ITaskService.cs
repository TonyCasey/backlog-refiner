using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Core.Models.DTO;
using Task = Tasks.Data.Entities.Task;

namespace Tasks.Core.Services
{
    public interface ITaskService
    {
        Task<Task> Get(Guid guid);

        Task<Task> Save(Task record);

        IQueryable<Task> Search(TaskSearchRequest searchRequest, Guid companyGuid);
    }
}
