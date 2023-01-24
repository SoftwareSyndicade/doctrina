using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace doctrine_api.Controllers
{
    [Route("v1/account")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class AccountController : Controller
    {
        [HttpPost("/register")]
        public IActionResult Register()
        {
            return Unauthorized();
        }
    }
}

