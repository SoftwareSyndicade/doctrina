﻿using System;
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
        public IActionResult Register([FromBody] AssistanceRequest request)
        {
            var userIdentity = HttpContext.User.Identity as ClaimsIdentity;
            var profileID = userIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            DataModels.AssistanceReuest assistanceRequest = _mapper.Map<DataModels.AssistanceReuest>(request);

            assistanceRequest.ID = Guid.NewGuid().ToString();
            assistanceRequest.CREATED_ON = DateTime.UtcNow;
            assistanceRequest.CREATED_BY = profileID;

            var status = _assistanceRequestManager.Register(assistanceRequest);

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

