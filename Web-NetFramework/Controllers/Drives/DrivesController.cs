using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_NetFramework.Services.IServices;

namespace Web_NetFramework.Controllers.Drives
{
    public class DrivesController : Controller
    {
        private IDrivesService _drivesService;
        public DrivesController(IDrivesService drivesService)
        {
            _drivesService = drivesService;
        }
        // GET: Drives
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Get My Drives
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> MeAsync()
        {
            try
            {
                var result = await _drivesService.MeAsync();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.StackTrace, JsonRequestBehavior.AllowGet);
            }
        }
    }
}