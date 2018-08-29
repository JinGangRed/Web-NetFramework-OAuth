using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security.Notifications;
using Owin;
using System.IdentityModel.Claims;
using Web_NetFramework.TokenStorage;
using Microsoft.Identity.Client;
using System.Web;

[assembly: OwinStartup(typeof(Web_NetFramework.Startup))]

namespace Web_NetFramework
{
    public partial class Startup
    {
        /// <summary>
        /// 配置总线
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            // 配置认证
            ConfigureAuth(app);
            // 配置服务
            ConfigureRegistrar(app);


        }
        
    }
}
