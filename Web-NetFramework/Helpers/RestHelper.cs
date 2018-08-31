using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Web_NetFramework.Helpers
{
    public class RestHelper
    {
        private WebRequest request;
        private HttpWebResponse response;
        private static RestHelper restHelper = new RestHelper();
        private RestHelper()
        {
        }
        /// <summary>
        /// 作为中间调用者，为Http请求添加认证信息
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="authProvider"></param>
        /// <param name="headerCollection"></param>
        /// <returns></returns>
        public static RestHelper RestServiceClient(string requestUri,IAuthProvider authProvider,WebHeaderCollection headerCollection = null)
        {
            var request = WebRequest.Create(requestUri);
            if(headerCollection == null)
            {
                headerCollection = new WebHeaderCollection();
            }
            headerCollection.Add(HttpRequestHeader.Authorization, authProvider.GetUserAccesstokenAsync().Result);

            request.Headers = headerCollection;
            restHelper.request = request;
            return restHelper;
        }
        /// <summary>
        /// 作为一个终结点，获取Http响应
        /// </summary>
        /// <returns></returns>
        public async Task<HttpWebResponse> GetResponseAsync()
        {
            if(restHelper.request == null)
            {
                throw new ArgumentNullException("The HttpRequest is Null");
            }
            restHelper.request.Method = "GET";
            restHelper.response =(HttpWebResponse) await restHelper.request.GetResponseAsync();
            return restHelper.response;
        }
        /// <summary>
        /// 作为一个终结点,获取响应的信息
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAsync()
        {
            if(restHelper.response == null)
            {
                await GetResponseAsync();
            }
            var response_str = string.Empty;
            
            using (var stream = restHelper.response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream,Encoding.UTF8))
                {
                    response_str = await reader.ReadToEndAsync();
                }
            }
            return response_str;
        }
        

    }
}