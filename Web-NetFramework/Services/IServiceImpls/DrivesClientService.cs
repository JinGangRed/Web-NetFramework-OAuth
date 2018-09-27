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
    public class DrivesClientService : IDrivesService
    {
        private readonly GraphServiceClient _serviceClient;
        public DrivesClientService()
        {
            _serviceClient = GraphSdkHelper.GetGraphServiceClient();
        }
        /// <summary>
        /// 获得我的One Drive 信息
        /// </summary>
        /// <returns></returns>
        public async Task<Drive> MeAsync()
        {
            var drive = await _serviceClient.Me.Drive.Request().GetAsync();
            return drive;
        }
    }
}