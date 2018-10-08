using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Graph;
using Web_NetFramework.Helpers;
using Web_NetFramework.Services.IServices;

namespace Web_NetFramework.Services.IServiceImpls
{
    public class PlanClientService : IPlanService
    {
        private readonly GraphServiceClient _serviceClient;
        public PlanClientService()
        {
            _serviceClient = GraphSdkHelper.GetGraphServiceClient();
        }
        public async Task<IList<PlannerPlan>> PlannerPlansAsync()
        {
            var plans = await _serviceClient.Me.Planner.Plans.Request().GetAsync();
            return plans;
        }
    }
}