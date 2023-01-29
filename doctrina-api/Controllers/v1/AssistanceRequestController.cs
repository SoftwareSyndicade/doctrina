﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using doctrine_api.Constants;
using System.Net.Mime;

namespace doctrine_api.Controllers.v1
{
    [ApiController]
    [Route(Endpoints.ASSISTANCE_REQUEST)]
    [Produces(MediaTypeNames.Application.Json)]
    public class AssistanceRequestController : Controller
    {
        [HttpPost(CRUDActions.REGISTER)]
        public IActionResult RegisterAssistance()
        {
            return Unauthorized();
        }

        [HttpGet(CRUDActions.FETCH)]
        public IActionResult FetchAssistances()
        {
            return Unauthorized();
        }
    }
}
