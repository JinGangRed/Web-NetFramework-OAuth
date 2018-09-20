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
    public class DriveItemsClientService : IDriveItemsService
    {
        private readonly GraphServiceClient _serviceClient;
        public DriveItemsClientService()
        {
            _serviceClient = GraphSdkHelper.GetGraphServiceClient();
        }
        public async Task<DriveItem> DriveItemAsync(string itemID)
        {
            var res = _serviceClient.Drive.Items[itemID].Request();
            //res.QueryOptions.Add(new QueryOption("$orderby", "createdDateTime"));
            var response = await res.Expand("children($expend=thumbnails)").GetAsync();
            return response;
        }

        
    }
}