using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_NetFramework.Services.IServices;

namespace Web_NetFramework.Controllers.Plan
{
    public class PlanController : Controller
    {
        private readonly IPlanService _planService;
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }
        // GET: Plan
        public ActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> PlansAsync()
        {
            try
            {
                var plans = await _planService.PlannerPlansAsync();
                return Json(plans, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.StackTrace, JsonRequestBehavior.AllowGet);

            }
            
        }
    }
}