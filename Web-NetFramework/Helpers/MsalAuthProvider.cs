using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Web_NetFramework.App_Resources;
using Web_NetFramework.TokenStorage;

namespace Web_NetFramework.Helpers
{
    public class MsalAuthProvider : IAuthProvider
    {
        private static string ClientID = ConfigurationManager.AppSettings["ClientID"];
        private static string ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];
        private static string RedirectUri = ConfigurationManager.AppSettings["RedirectUri"];
        private static string Tenant = ConfigurationManager.AppSettings["Tenant"];
        private static string EndPointUri = ConfigurationManager.AppSettings["EndPointURi"];
        private static string EndPointVersion = ConfigurationManager.AppSettings["EndPointVersion"];

        private static string Scope = ConfigurationManager.AppSettings["Scope"];

        private static TokenSessionCache tokenCache { get; set; }

        private MsalAuthProvider() { }

        public static MsalAuthProvider Instance { get; } = new MsalAuthProvider();

        /// <summary>
        /// 使用该方法获取Access Token
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetUserAccesstokenAsync()
        {
            string singedInUserID = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            HttpContextWrapper httpContext = new HttpContextWrapper(HttpContext.Current);
            TokenCache userTokenCache = new TokenSessionCache(singedInUserID, httpContext).GetMsalCacheInstance();
            ConfidentialClientApplication confidential = new ConfidentialClientApplication(
                ClientID,
                RedirectUri,
                new ClientCredential(ClientSecret),
                userTokenCache,
                null);
            
            string[] scopes = Scope.Split(new char[] { ' ' });
            try
            {
                AuthenticationResult result = await confidential.AcquireTokenSilentAsync(scopes, confidential.Users.First());
                return result.AccessToken;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Request.GetOwinContext().Authentication.Challenge(
                    new Microsoft.Owin.Security.AuthenticationProperties() { RedirectUri = "/" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
                throw new ServiceException(
                    new Error
                    {
                        Code = GraphErrorCode.AuthenticationFailure.ToString(),
                        Message = Resource.Error_AuthChallengeNeeded,
                    });
            }
        }
    }
}