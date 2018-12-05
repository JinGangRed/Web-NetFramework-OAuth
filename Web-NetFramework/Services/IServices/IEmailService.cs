using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_NetFramework.Services.IServices
{
    /// <summary>
    /// 邮件相关服务类
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// 获得我的个人邮件
        /// </summary>
        /// <param name="pagesize">页面大小，默认页面大小为10封邮件</param>
        /// <returns></returns>
        Task<IList<Message>> MeAsync(int pagesize = 10);
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toaddress">收件人</param>
        /// <returns></returns>
        Task SendAsync(Message message);


        Task<IMailFolderMessageRulesCollectionPage> MessageRulesAsync(string userId);

    }
}
