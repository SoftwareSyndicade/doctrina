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

namespace doctrine_api.Controllers.v1
{
    [ApiController]
    [Route(Endpoints.ASSISTANCE_REQUEST)]
    [Produces(MediaTypeNames.Application.Json)]
    public class AssistanceRequestController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAssistanceRequestManager _assistanceRequestManager;

        public AssistanceRequestController(IMapper mapper, IAssistanceRequestManager assistanceRequestManager)
        {
            _mapper = mapper;
            _assistanceRequestManager = assistanceRequestManager;
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
            return Unauthorized();
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

