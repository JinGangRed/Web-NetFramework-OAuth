using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_NetFramework.Services.IServices;

namespace Web_NetFramework.Controllers.User
{
    public class PhotoController : Controller
    {
        private readonly IUserService _userService;
        public PhotoController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<JsonResult> MeAsync()
        {
            try
            {
               var result = await _userService.PhotoAsync();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}