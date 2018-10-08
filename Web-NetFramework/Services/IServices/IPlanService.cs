using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_NetFramework.Services.IServices
{
    public interface IPlanService
    {
        /// <summary>
        /// 获取所有的计划
        /// </summary>
        /// <returns></returns>
        Task<IList<PlannerPlan>> PlannerPlansAsync();
    }
}
