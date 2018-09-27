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
    /// <summary>
    /// 使用GraphClient获取用户信息
    /// </summary>
    public class UserClientService : IUserService
    {
        private readonly GraphServiceClient _serviceClient;
        public UserClientService()
        {
            _serviceClient = GraphSdkHelper.GetGraphServiceClient();
        }
        /// <summary>
        /// 获得我的个人信息
        /// </summary>
        /// <returns></returns>
        public async Task<User> MeAsync()
        {
            var me = await _serviceClient.Me.Request().GetAsync();
            return me;
        }

        public User GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task DriveAsync()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获得所有用户
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> UsersAsync()
        {
            var users = await _serviceClient.Users.Request().GetAsync();
            //#region Case Handle
            //var users = await _serviceClient.Users.Request()
            //    .Select("displayName,mobilePhone,mail,photo,department,jobTitle,mailNickname")
            //    .Top(20).GetAsync();

            //#endregion
            return users.ToList();
        }
        /// <summary>
        /// 获得我的照片
        /// </summary>
        /// <returns></returns>
        public async Task<ProfilePhoto> PhotoAsync()
        {
            var photo = await _serviceClient.Me.Photo.Request().GetAsync();
            return photo;
        }
    }
}