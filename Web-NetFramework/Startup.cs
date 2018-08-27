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
    public class Startup
    {
        private static string ClientID = ConfigurationManager.AppSettings["ClientID"];
        private static string ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];
        private static string RedirectUri = ConfigurationManager.AppSettings["RedirectUri"];
        private static string Tenant = ConfigurationManager.AppSettings["Tenant"];
        private static string EndPointUri = ConfigurationManager.AppSettings["EndPointURi"];
        private static string EndPointVersion = ConfigurationManager.AppSettings["EndPointVersion"];

        private static string Scope = ConfigurationManager.AppSettings["Scope"];


        public void Configuration(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = ClientID,
                    Authority = EndPointUri + Tenant + "/" + EndPointVersion,
                    PostLogoutRedirectUri = RedirectUri,
                    RedirectUri = RedirectUri,
                    Scope = "openid email profile offline_access " + Scope,
                    ResponseType = OpenIdConnectResponseType.IdToken,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false
                    },
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthenticationFailed = OnAuthenticationFailed,
                        AuthorizationCodeReceived = AuthorizationCodeReceived
                    });
        }
        /// <summary>
        /// 认证失败
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private Task OnAuthenticationFailed(AuthenticationFailedNotification<OpenIdConnectMessage,OpenIdConnectAuthenticationOptions> context)
        {
            context.HandleResponse();
            context.Response.Redirect("/?errormessage=" + context.Exception.Message);
            return Task.FromResult(0);
        }
        private async Task AuthorizationCodeReceived(AuthorizationCodeReceivedNotification context)
        {
            var code = context.Code;
            var signedInUserID = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            TokenCache tokenCache = new TokenSessionCache(signedInUserID, context.OwinContext.Environment["System.Web.HttpContextBase"] as HttpContextBase).GetMsalCacheInstance();
            ConfidentialClientApplication confidential = new ConfidentialClientApplication(
                ClientID,
                RedirectUri,
                new ClientCredential(ClientSecret),
                tokenCache,
                null);
            string[] scopes = Scope.Split(new char[] { ' ' });
            AuthenticationResult result = await confidential.AcquireTokenByAuthorizationCodeAsync(code, scopes);
        }
    }
}
