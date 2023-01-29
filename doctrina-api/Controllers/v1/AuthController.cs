using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using doctrine_api.Constants;
using Microsoft.AspNetCore.Mvc;
using doctrine_api.RequestModels;
using doctrine_api.ResponseModels;
using doctrine_api.Auth;

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
        private IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        /// <summary>
        /// Endoint action to sign in user into system by validation credentioals.
        /// </summary>
        /// <returns></returns>
        [HttpPost(AuthActions.SIGN_IN)]
        public IActionResult SignIn([FromBody] SignInRequest signInRequest)
        {
            SignInResponse response = new SignInResponse();

            Auth.SignInResult result = _authManager.ValidateUser(signInRequest);
            if (!result.IS_VALIDATED)
            {
                response.IS_VALIDATED = false;
                response.ERRORS.AddRange(result.ERRORS);
                return Unauthorized(response);
            }

            response.IS_VALIDATED = true;

            return Ok(response);
        }
    }
}

