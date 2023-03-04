using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

namespace doctrine_api.Services.Google.Calendar
{
    public class GoogleCalendarService : IGoogleCalendarService
    {
        private CalendarService _calendarService;

        public GoogleCalendarService()
        {
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
               new ClientSecrets
               {
                   ClientId = "838726120450-ns7pqcq4fh3eaap7l52dp2kke65cfj0k.apps.googleusercontent.com",
                   ClientSecret = "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"
               },
               new[] { CalendarService.Scope.Calendar },
               "user",
               CancellationToken.None
            ).Result;

            _calendarService = new(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Doctrina tutoring"
            });
        }

        public void RegisterEvent()
        {
            Event calendarEvent = new()
            {
                Summary = "Test summary",
                Location = "Test location",
                Description = "Test description",
                Start = new()
                {
                    DateTime = DateTime.UtcNow.AddDays(3)
                },
                End = new()
                {
                    DateTime = DateTime.UtcNow.AddDays(4)
                },
                Attendees = new EventAttendee[]
                {
                    new() { Email = "itsbibeksaini@gmail.com" },
                    new() { Email = "manu_prashar@hotmail.com" }
                },

                ConferenceData = new()
                {
                    CreateRequest = new()
                    {
                        RequestId = Guid.NewGuid().ToString(),
                        ConferenceSolutionKey = new() { Type = "hangoutsMeet" }
                    },
                }

            };

            try
            {
                EventsResource.InsertRequest insertRequest = _calendarService.Events.Insert(calendarEvent, "primary");
                insertRequest.ConferenceDataVersion = 1;
                Event newEvent = insertRequest.Execute();
                Console.WriteLine("Event created {0}", newEvent.HtmlLink);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}

