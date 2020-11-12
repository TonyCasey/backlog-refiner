using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Email.Business.Extensions;
using Email.Core.Models.DTO;
using Email.Core.Services;
using Email.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Email.Business.Services
{
    public class EmailService : IEmailService
    {
        private readonly ApplicationDbContext _dbContext;

        public EmailService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Data.Entities.Email> Get(Guid guid)
        {
            return await _dbContext.Emails.FirstOrDefaultAsync(x => x.Guid == guid && x.Deleted != true);
        }

        public async Task<Data.Entities.Email> Save(Data.Entities.Email record)
        {
            if (record.EmailId <= 0)
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

        public IQueryable<Data.Entities.Email> Search(EmailSearchRequest searchRequest, Guid companyGuid) => _dbContext
            .Emails
            .AsNoTracking()
            .NotDeleted()
            .ForCompany(companyGuid)
            .ForTicket(searchRequest.TicketGuid)
            .ForNotification(searchRequest.NotificationGuid)
            .OrderBy(x => x.EmailId )
            .AsQueryable();
    }
}
