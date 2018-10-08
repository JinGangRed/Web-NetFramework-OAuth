using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Graph;
using Web_NetFramework.Helpers;
using Web_NetFramework.Services.IServices;

namespace Web_NetFramework.Services.IServiceImpls
{
    public class CalendarClientService : ICalendarService
    {
        private readonly GraphServiceClient _serviceClient;
        public CalendarClientService()
        {
            _serviceClient = GraphSdkHelper.GetGraphServiceClient();
        }
        /// <summary>
        /// 获取某个日历的内容
        /// </summary>
        /// <param name="calendarId"></param>
        /// <returns></returns>
        public async Task<Calendar> CalendarAsync(string calendarId)
        {
            var calendar = await _serviceClient.Me.Calendars[calendarId].Request().GetAsync();
            return calendar;
        }

        /// <summary>
        /// 列出特定日历中的事件列表
        /// </summary>
        /// <param name="calendarId"></param>
        /// <returns></returns>
        public async Task<ICollection<Event>> EventsAsync(string calendarId)
        {
            var events = await _serviceClient.Me.Calendars[calendarId].Events.Request().GetAsync();
            return events.CurrentPage;
        }
    }
}