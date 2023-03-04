using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using doctrine_api.Services.Google.Calendar.models;
using Microsoft.Extensions.Options;

namespace doctrine_api.Services.Google.Calendar
{
    public class GoogleCalendarService : IGoogleCalendarService
    {
        private CalendarService _calendarService;

        public GoogleCalendarService(IOptions<GoogleClientSecret> clientSecrets)
        {
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
               new ClientSecrets
               {
                   ClientId = clientSecrets.Value.CLIENT_ID,
                   ClientSecret = clientSecrets.Value.CLIENT_SECRET
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

        public void RegisterEvent(CalendarEvent cv)
        {
            Event calendarEvent = new()
            {
                Summary = cv.SUMMARY,
                Location = cv.LOCATION,
                Description = cv.DESCRIPTION,
                Start = new()
                {
                    DateTime = cv.START
                },
                End = new()
                {
                    DateTime = cv.END
                },
                Attendees = cv.ATTENDEES,

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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}

