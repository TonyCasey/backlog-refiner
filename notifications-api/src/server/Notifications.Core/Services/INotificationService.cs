using Notifications.Core.Models.DTO;
using Notifications.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Core.Services
{
    public interface INotificationService
    {
        Task<Notification> Get(Guid guid);

        Task<Notification> Save(Notification record);

        IQueryable<Notification> Search(SearchRequest searchRequest, Guid companyGuid);
    }
}
