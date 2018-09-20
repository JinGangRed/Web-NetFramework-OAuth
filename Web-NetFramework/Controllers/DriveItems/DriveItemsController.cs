using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_NetFramework.Services.IServices;

namespace Web_NetFramework.Controllers.DriveItems
{
    /**
     * DriveItems 
     * */
    public class DriveItemsController : Controller
    {
        private readonly IDriveItemsService _driveItemsService;
        public DriveItemsController(IDriveItemsService driveItemsService)
        {
            _driveItemsService = driveItemsService;
        }
        // GET: DriveItems
        public ActionResult Index()
        {
            return View();
        }
    }
}