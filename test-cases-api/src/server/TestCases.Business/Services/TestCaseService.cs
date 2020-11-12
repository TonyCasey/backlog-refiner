using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestCases.Business.Extensions;
using TestCases.Core.Models.DTO;
using TestCases.Core.Services;
using TestCases.Data.Entities;
using TestCases.Data.EntityFramework;

namespace TestCases.Business.Services
{
    public class TestCaseService : ITestCaseService
    {
        private readonly ApplicationDbContext _dbContext;

        public TestCaseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TestCase> Get(Guid guid)
        {
            return await _dbContext.TestCases.FirstOrDefaultAsync(x => x.Guid == guid && x.Deleted != true);
        }

        public async Task<TestCase> Save(TestCase record)
        {
            if (record.TestCaseId <= 0)
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

        public IQueryable<TestCase> Search(TestCaseSearchRequest searchRequest, Guid companyGuid) => _dbContext
            .TestCases
            .AsNoTracking()
            .NotDeleted()
            .ForCompany(companyGuid)
            .ForBaord(searchRequest.BoardGuid)
            .ForTicket(searchRequest.TicketGuid)
            .AsQueryable();
    }
}
