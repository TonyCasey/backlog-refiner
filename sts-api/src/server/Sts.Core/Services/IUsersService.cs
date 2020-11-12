using System;
using System.Threading.Tasks;
using Sts.Core.Models;
using Optional;
using Sts.Data.Entities;

namespace Sts.Core.Services
{
    public interface IUsersService
    {
        Task<Option<JwtModel, Error>> Login(LoginUserModel model);

        Task<Option<UserModel, Error>> Register(RegisterUserModel model);

        Task<User> Get(Guid guid);
    }
}
