using Microsoft.Graph;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_NetFramework.Services.IServices;

namespace Web_NetFramework.Controllers.User
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService):base()
        {
            _userService = userService;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 查询我的个人信息
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> MeAsync()
        {
            try
            {
                var me = await _userService.MeAsync();
                return Json(me,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.StackTrace,JsonRequestBehavior.AllowGet);

            }
        }
        /// <summary>
        /// 所有用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> UsersAsync()
        {
            try
            {
                var users = await _userService.UsersAsync();
                return Json(users,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }
    }
}