using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_NetFramework.Services.IServices;

namespace Web_NetFramework.Controllers.Email
{
    /// <summary>
    /// 邮件相关的服务类
    /// </summary>
    public class EmailController : BaseController
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        // GET: Email
        public async Task<ActionResult> MeAsync()
        {
            var messages = await _emailService.MeAsync();
            ViewBag.Emails = messages;
            return View("Index");
        }
    }
}