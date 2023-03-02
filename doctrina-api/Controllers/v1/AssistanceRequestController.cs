using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using doctrine_api.Constants;
using System.Net.Mime;
using doctrine_api.RequestModels;
using AutoMapper;
using doctrine_api.Management.Assistance.Request;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using doctrine_api.Management.Account;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Calendar.v3.Data;
using static Google.Apis.Calendar.v3.AclResource;

namespace doctrine_api.Controllers.v1
{
    [Authorize]
    [ApiController]
    [Route(Endpoints.ASSISTANCE_REQUEST)]
    [Produces(MediaTypeNames.Application.Json)]
    public class AssistanceRequestController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAssistanceRequestManager _assistanceRequestManager;
        private readonly IAccountManager _accountManager;

        public AssistanceRequestController(IMapper mapper, IAssistanceRequestManager assistanceRequestManager, IAccountManager accountManager)
        {
            _mapper = mapper;
            _assistanceRequestManager = assistanceRequestManager;
            _accountManager = accountManager;
        }


        [HttpPost(CRUDActions.REGISTER)]
        public async Task<IActionResult> Register([FromBody] AssistanceRequest request)
        {
            var userIdentity = HttpContext.User.Identity as ClaimsIdentity;
            var profileID = userIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            DataModels.AssistanceReuest assistanceRequest = _mapper.Map<DataModels.AssistanceReuest>(request);

            assistanceRequest.ID = Guid.NewGuid().ToString();
            assistanceRequest.CREATED_ON = DateTime.UtcNow;
            assistanceRequest.CREATED_BY = profileID;

            var status = _assistanceRequestManager.Register(assistanceRequest);

            UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = "838726120450-ns7pqcq4fh3eaap7l52dp2kke65cfj0k.apps.googleusercontent.com",
                    ClientSecret = "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"
                },
                new[] { CalendarService.Scope.Calendar },
                "user",
                CancellationToken.None
            ); ;

            CalendarService calendarService = new(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Doctrina tutoring"
            });

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
                EventsResource.InsertRequest insertRequest = calendarService.Events.Insert(calendarEvent, "primary");
                insertRequest.ConferenceDataVersion = 1;
                Event newEvent = insertRequest.Execute();
                Console.WriteLine("Event created {0}", newEvent.HtmlLink);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }


            if (status.IS_SAVED)
                return StatusCode(StatusCodes.Status201Created);

            return BadRequest();
        }

        [HttpGet(CRUDActions.FETCH)]
        public IActionResult Fetch()
        {
            var userIdentity = HttpContext.User.Identity as ClaimsIdentity;
            var profileID = userIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var account = _accountManager.GetAccount(profileID);

            var result = _assistanceRequestManager.Fetch(profileID, account.ACCOUNT_TYPE);

            if (result == null || result.Count == 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPut(CRUDActions.UPDATE)]
        public IActionResult Update()
        {
            return Unauthorized();
        }

        [HttpDelete(CRUDActions.DELETE)]
        public IActionResult Delete()
        {
            return Unauthorized();
        }
    }
}

