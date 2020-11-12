using System;
using System.Collections.Generic;
using System.Text;
using Sts.Core.Models;
using Sts.Data.Entities;

namespace Sts.Core.Services
{
    public interface ICompanyService
    {
        Company GetCompany(Guid guid);

        Company GetCompany(string domainName);

        Company GetCompany(string domainName, string companyName);

        Company AddUpdateCompany(Company company);
    }
}
