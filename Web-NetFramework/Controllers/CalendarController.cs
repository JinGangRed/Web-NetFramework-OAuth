using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_NetFramework.Services.IServices;

namespace Web_NetFramework.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICalendarService _calendarService;
        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> CalendarAsync()
        {
            var calendarId = "AAMkADU0ZmE1ZmE1LWMwMzgtNDY2My04ZjhmLWMxODExMjk5MmQ4MABGAAAAAADqWUYzsipPQrq2IvdyDuzqBwB02rBOcGAoRZfV1jwCjO6MAAAAAAEGAAB02rBOcGAoRZfV1jwCjO6MAAAAAB0WAAA=";
            try
            {
                var result = await _calendarService.CalendarAsync(calendarId);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.StackTrace, JsonRequestBehavior.AllowGet);
            }
        }


        public async Task<JsonResult> EventsAsync()
        {
            var calendarId = "AAMkADU0ZmE1ZmE1LWMwMzgtNDY2My04ZjhmLWMxODExMjk5MmQ4MABGAAAAAADqWUYzsipPQrq2IvdyDuzqBwB02rBOcGAoRZfV1jwCjO6MAAAAAAEGAAB02rBOcGAoRZfV1jwCjO6MAAAAAB0WAAA=";
            try
            {
                var result = await _calendarService.EventsAsync(calendarId);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.StackTrace);
            }

        }
    }
}