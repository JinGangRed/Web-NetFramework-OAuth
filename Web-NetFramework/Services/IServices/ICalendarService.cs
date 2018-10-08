using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_NetFramework.Services.IServices
{
    public interface ICalendarService
    {
        Task<ICollection<Event>> EventsAsync(string calendarId);


        Task<Calendar> CalendarAsync(string calendarId);
    }
}
