using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_NetFramework.Services.IServices
{
    /// <summary>
    /// 获得用户信息
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <returns></returns>
        User GetUser();
        /// <summary>
        /// 获得我的个人信息11
        /// </summary>
        /// <returns></returns>
        Task<User> MeAsync();

        /// <summary>
        /// 获得我的Drive信息
        /// </summary>
        /// <returns></returns>
        Task DriveAsync();
    }
}
