using Email.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Email.Core.Services
{
    public interface IUserService
    {
        Task<User> Get(Guid guid);
    }
}
