using System;
using System.Linq;
using System.Threading.Tasks;
using Email.Core.Models.DTO;

namespace Email.Core.Services
{
    public interface IEmailService
    {
        Task<Data.Entities.Email> Get(Guid guid);

        Task<Data.Entities.Email> Save(Data.Entities.Email record);

        IQueryable<Data.Entities.Email> Search(EmailSearchRequest searchRequest, Guid companyGuid);
    }
}
