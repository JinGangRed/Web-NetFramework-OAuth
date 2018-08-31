using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Graph;
using Web_NetFramework.Helpers;
using Web_NetFramework.Services.IServices;

namespace Web_NetFramework.Services.IServiceImpls
{
    public class EmailClientService : IEmailService
    {
        private readonly GraphServiceClient _serviceClient;
        public EmailClientService()
        {
            _serviceClient = GraphSdkHelper.GetGraphServiceClient();
        }
        /// <summary>
        /// 获得我的个人消息
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Message>> MeAsync(int pagesize = 10)
        {
            var collectionMessagePage = await _serviceClient.Me.Messages.Request().Top(20).GetAsync();
            var  count = collectionMessagePage.Count; //The default page size for this request is 10 messages.
            return collectionMessagePage.CurrentPage;
        }
    }
}