using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_NetFramework.Helpers
{
    public class GraphSdkHelper
    {
        public static GraphServiceClient GetGraphServiceClient()
        {
            GraphServiceClient graphServiceClient = new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    async (requestMessage) =>
                    {
                        string accessToken = await MsalAuthProvider.Instance.GetUserAccesstokenAsync();
                        requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", accessToken);
                    }));
            return graphServiceClient;
        }
    }
}