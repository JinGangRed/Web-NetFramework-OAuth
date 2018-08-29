using Microsoft.Graph;
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
        public async Task<ActionResult> Index()
        {
            var str = await _userService.TestStringAsync();
            ViewBag.Mail = str;
            return View();
        }
    }
}