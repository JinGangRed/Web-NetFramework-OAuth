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
    public class EmailRestService : IEmailService
    {
        public async Task<IList<Message>> MeAsync(int pagesize = 10)
        {
            var startDate = "2018-08-07T22:00:00Z";
            var endDate = "2018-09-28T22:00:00Z";
            var format = @"?$search=""received >={0}AND received<={1}""&$select=id&$top=100";
            var url = RestAPIUrl.BaseUrl + RestAPIUrl.Version_1 + RestAPIUrl.Me + RestAPIUrl.Messages +
                string.Format(format, startDate, endDate);

            var messages_Info = await RestHelper.RestServiceClient(url, MsalAuthProvider.Instance).GetAsync();

            var messages = JsonConvert.DeserializeObject<IUserMessagesCollectionPage>(messages_Info);


            var count = messages.Count;

            return null;



        }

        public Task<IMailFolderMessageRulesCollectionPage> MessageRulesAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task SendAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}