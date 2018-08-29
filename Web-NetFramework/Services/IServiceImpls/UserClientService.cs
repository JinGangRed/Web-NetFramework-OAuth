using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web_NetFramework.Helpers;
using Web_NetFramework.Services.IServices;

namespace Web_NetFramework.Services.IServiceImpls
{
    public class UserClientService : IUserService
    {
        private readonly GraphServiceClient _serviceClient;
        public UserClientService()
        {
            _serviceClient = GraphSdkHelper.GetGraphServiceClient();
        }

        public async Task<string> TestStringAsync()
        {
            User me = await _serviceClient.Me.Request().Select("mail").GetAsync();
            return me.Mail;
        }
    }
}