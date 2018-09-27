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
    public class DriveClientService : IDriveService
    {
        private readonly GraphServiceClient _serviceClient;
        public DriveClientService()
        {
            _serviceClient = GraphSdkHelper.GetGraphServiceClient();
        }
        /// <summary>
        /// 获得我的根目录下的Drive
        /// </summary>
        /// <returns></returns>
        public async Task<DriveItem> MeRootAsync()
        {
            var drive = await _serviceClient.Me.Drive.Root.Request().GetAsync();
            return drive;
        }
    }
}