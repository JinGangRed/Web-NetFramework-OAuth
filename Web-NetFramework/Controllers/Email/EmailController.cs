using Microsoft.Graph;
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
        public ActionResult Index()
        {
            return View();
        }
        // GET: Email
        public async Task<JsonResult> MeAsync()
        {
            try
            {
                var messages = await _emailService.MeAsync();
                return Json(messages, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.StackTrace, JsonRequestBehavior.AllowGet);
            }
        }
        // Get: sendMail
        public async Task<JsonResult> SendAsync(string toAddress)
        {
            #region Set the Email Information
            EmailAddress recipient = new EmailAddress
            {
                Address = toAddress
            };
            var subject = "Test for sending an Email";
            var emailBody = new ItemBody
            {
                Content = "Email Content",
                ContentType = BodyType.Text, // This property can be BodyType.Text or BodyType.Html
            };
            var message = new Message
            {
                Subject = subject,
                Body = emailBody,
                ToRecipients = new List<Recipient>
                {
                    new Recipient
                    {
                        EmailAddress = recipient
                    }
                }
            };
            #endregion
            try
            {
                await _emailService.SendAsync(message);
                return Json(new { message = "OK" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.StackTrace }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}