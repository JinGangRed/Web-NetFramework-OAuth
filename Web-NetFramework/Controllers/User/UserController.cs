﻿using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_NetFramework.Controllers.User
{
    public class UserController : BaseController
    {
        
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}