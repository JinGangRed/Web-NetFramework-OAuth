using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Graph;
using Newtonsoft.Json;
using Web_NetFramework.App_Resources;
using Web_NetFramework.Helpers;
using Web_NetFramework.Services.IServices;

namespace Web_NetFramework.Services.IServiceImpls
{
    /// <summary>
    /// 使用REST
    /// </summary>
    public class UserRestService : IUserService
    {
        
        public UserRestService()
        {
            
        }
        public Task DriveAsync()
        {
            throw new NotImplementedException();
        }

        public User GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> MeAsync()
        {
            var url = RestAPIUrl.BaseUrl + RestAPIUrl.Version_1 + RestAPIUrl.Me;
            var userInfo = await RestHelper.RestServiceClient(url, MsalAuthProvider.Instance).GetAsync();

            var user = JsonConvert.DeserializeObject<User>(userInfo);

            return user;

        }

        public Task<ProfilePhoto> PhotoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> UsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}