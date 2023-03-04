using System;
using Google.Apis.Calendar.v3.Data;

namespace doctrine_api.Services.Google.Calendar.models
{
    public class CalendarEvent
    {
        public string SUMMARY { get; set; }
        public string DESCRIPTION { get; set; }
        public string LOCATION { get; set; }
        public DateTime START { get; set; }
        public DateTime END { get; set; }
        public bool SETUP_MEET { get; set; }
        public EventAttendee[] ATTENDEES { get; set; }
    }
}

