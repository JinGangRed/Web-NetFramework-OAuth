using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Web_NetFramework.App_Start.Startup1))]

namespace Web_NetFramework.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
