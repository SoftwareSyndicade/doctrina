using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using doctrine_api.Constants;
using Microsoft.AspNetCore.Mvc;

namespace doctrine_api.Controllers.v1
{
    /// <summary>
    /// Auth controller endpoint for authentication user intot system.
    /// </summary>
    [Route(Endpoints.AUTH)]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class AuthController : Controller
    {
        /// <summary>
        /// Endoint action to sign in user into system by validation credentioals.
        /// </summary>
        /// <returns></returns>
        [HttpPost(AuthActions.SIGN_IN)]
        public IActionResult SignIn()
        {
            return Ok();
        }
    }
}

