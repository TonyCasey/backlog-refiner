using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Sts.Core.Models;
using Sts.Core.Services;
using Sts.Data.Entities;
using Sts.Data.EntityFramework;

namespace Sts.Business.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CompanyService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Company GetCompany(Guid guid)
        {
            return _dbContext.Companies.FirstOrDefault(x => x.Guid == guid);
        }

        public Company GetCompany(string domainName)
        {
            return _dbContext.Companies.FirstOrDefault(x => x.DomainName == domainName);
        }

        public Company GetCompany(string domainName, string companyName)
        {
            return _dbContext.Companies.FirstOrDefault(x => x.DomainName == domainName || x.Name == companyName);
        }

        public Company AddUpdateCompany(Company company)
        {

            var existing = _dbContext.Companies.FirstOrDefault(x => x.Guid == company.Guid);

            if (existing != null)
                _dbContext.Companies.Update( _mapper.Map(company, existing));
            else
            {
                company.Guid = Guid.NewGuid();
                _dbContext.Companies.Add(company);
            }

            _dbContext.SaveChanges();

            return company;

        }
    }
}
