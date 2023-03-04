using System;
using doctrine_api.Services.Google.Calendar.models;

namespace doctrine_api.Services.Google.Calendar
{
    public interface IGoogleCalendarService
    {
        public void RegisterEvent(CalendarEvent calendarEvent);
    }
}

