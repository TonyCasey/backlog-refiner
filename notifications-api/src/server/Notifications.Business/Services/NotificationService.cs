using Notifications.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notifications.Business.Extensions;
using Notifications.Core.Models.DTO;
using Notifications.Data.Entities;
using Notifications.Data.EntityFramework;

namespace Notifications.Business.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _dbContext;

        public NotificationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Notification> Get(Guid guid)
        {
            return await _dbContext.Notifications.FirstOrDefaultAsync(x => x.Guid == guid && x.Deleted != true);
        }

        public async Task<Notification> Save(Notification record)
        {
            if (record.NotificationId <= 0)
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

        public IQueryable<Notification> Search(SearchRequest searchRequest, Guid companyGuid) => _dbContext
            .Notifications
            .AsNoTracking()
            .NotDeleted()
            .ForUser(searchRequest.UserGuid)
            .ForCompany(companyGuid)
            .ForBoard(searchRequest.BoardGuid)
            .ForTicket(searchRequest.TicketGuid)
            .ForStatus(searchRequest.StatusId)
            .AsQueryable();
    }
}
