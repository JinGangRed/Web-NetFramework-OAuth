using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Graph;
using Microsoft.Owin;
using Owin;
using Web_NetFramework.Services.IServiceImpls;
using Web_NetFramework.Services.IServices;

namespace Web_NetFramework
{
    /// <summary>
    /// 用于注入服务
    /// </summary>
    public partial class Startup
    {
        private readonly Boolean UserGraphClient = Boolean.Parse(ConfigurationManager.AppSettings["UseGraphClient"]);
        public void ConfigureRegistrar(IAppBuilder app)
        {
            
            var container = RegisterService();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);

            app.UseAutofacMvc();
        }
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        private IContainer RegisterService()
        {
            var builder = new ContainerBuilder();
            //如果使用GraphClient,则在webConfig中配置UserGraphClient属性
            if (UserGraphClient)
            {
                builder.RegisterType<UserClientService>().As<IUserService>().InstancePerLifetimeScope();
                builder.RegisterType<EmailClientService>().As<IEmailService>().InstancePerLifetimeScope();
                builder.RegisterType<DriveItemsClientService>().As<IDriveItemsService>().InstancePerLifetimeScope();
            }
            else
            {
                //注入REST实现的服务
                builder.RegisterType<UserRestService>().As<IUserService>().InstancePerLifetimeScope();

            }
            

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            return container;
        }
    }
}
