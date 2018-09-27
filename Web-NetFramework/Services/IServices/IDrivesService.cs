using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Web_NetFramework.Services.IServices
{
    /// <summary>
    /// The drive resource is the top level object representing a user's OneDrive or a document library in SharePoint.
    /// </summary>
    public interface IDrivesService
    {
        /// <summary>
        /// 获得我的One Drive 内容
        /// </summary>
        /// <returns></returns>
        Task<Drive> MeAsync();
    }
}