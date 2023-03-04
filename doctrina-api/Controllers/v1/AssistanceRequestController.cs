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
using doctrine_api.Services.Google.Calendar;

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
        private readonly IGoogleCalendarService _googleCalendarService;

        public AssistanceRequestController(IMapper mapper, IAssistanceRequestManager assistanceRequestManager, IAccountManager accountManager, IGoogleCalendarService googleCalendarService)
        {
            _mapper = mapper;
            _assistanceRequestManager = assistanceRequestManager;
            _accountManager = accountManager;
            _googleCalendarService = googleCalendarService;
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

            var userAccount = _accountManager.GetAccount(profileID);


            if (assistanceRequest.SETUP_MEETING)
                _googleCalendarService.RegisterEvent(new()
                {
                    DESCRIPTION = assistanceRequest.DETAILS,
                    SUMMARY = assistanceRequest.CATEGORY + " event",
                    ATTENDEES = new EventAttendee[] {
                    new(){ Email = userAccount.EMAIL }
                },
                    START = assistanceRequest.CREATED_ON,
                    END = assistanceRequest.CREATED_ON.AddDays(1),
                    SETUP_MEET = assistanceRequest.SETUP_MEETING
                });


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

