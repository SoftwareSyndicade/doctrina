using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace doctrine_api.Controllers
{
    [Route("v1/auth")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class AuthController : Controller
    {
        [HttpPost("/sign-in")]
        public IActionResult SignIn()
        {
            return Unauthorized();
        }
    }
}

