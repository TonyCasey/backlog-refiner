using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCases.Core.Models.DTO;
using TestCases.Data.Entities;

namespace TestCases.Core.Services
{
    public interface ITestCaseService
    {
        Task<TestCase> Get(Guid guid);

        Task<TestCase> Save(TestCase record);

        IQueryable<TestCase> Search(TestCaseSearchRequest searchRequest, Guid companyGuid);

    }
}
