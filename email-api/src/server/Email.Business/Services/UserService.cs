using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Email.Business.AutoRrest;
using Email.Core.Configuration;
using Email.Data.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Rest;

namespace Email.Business.Services
{
    public class UserService : Core.Services.IUserService
    {
        private IStsApi _stsApi;

        public UserService(IOptions<StsConfiguration> config)
        {
            _stsApi = new StsApi(new Uri(config.Value.BaseUrl),
                    new TokenCredentials(config.Value.Token, "Bearer"));
        }

        public async Task<User> Get(Guid guid)
        {
            try
            {
                var user = await _stsApi.Get2WithHttpMessagesAsync(guid);
                var userModel = (Email.Business.AutoRrest.Models.UserModel) user.Body;
                return new User
                {
                    Email = userModel.Email,
                    Avatar = userModel.Avatar,
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    CompanyGuid = (Guid)userModel.CompanyGuid
                };
            }
            catch (Exception e)
            {
                return null;
            }
 
        }
    }
}
