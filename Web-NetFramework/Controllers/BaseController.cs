﻿using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_NetFramework.Helpers;

namespace Web_NetFramework.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public BaseController()
        {
            GetAccessTokenAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 获取Accesstoken
        /// </summary>
        /// <returns></returns>
        public async Task GetAccessTokenAsync()
        {
            MsalAuthProvider authProvider = MsalAuthProvider.Instance;
            try
            {
                var accesstoken = await authProvider.GetUserAccesstokenAsync();
                ViewBag.AccessToken = accesstoken;
            }
            catch (ServiceException ex)
            {
                HttpContext.Response.RedirectToRoute("Error/Index", new { message = App_Resources.Resource.Error_Message + Request.RawUrl + ": " + ex.Error.Message });
            }
        }
        
    }
}