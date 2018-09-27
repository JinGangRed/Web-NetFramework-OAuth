using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_NetFramework.Services.IServices
{
    public interface IDriveService
    {
        /// <summary>
        /// 获取我的root 下的Drive
        /// </summary>
        /// <returns></returns>
        Task<DriveItem> MeRootAsync();
    }
}
