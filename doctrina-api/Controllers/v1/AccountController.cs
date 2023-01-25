using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using doctrine_api.AccountManagement;
using doctrine_api.Constants;
using doctrine_api.DataModels;
using doctrine_api.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace doctrine_api.Controllers.v1
{
    [Route(Endpoints.ACCOUNT)]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;

        public AccountController(IMapper mapper, IAccountManager accountManager)
        {
            _mapper = mapper;
            _accountManager = accountManager;
        }


        [HttpPost(AccountActions.REGISTER)]
        public IActionResult Register(AccountDetails accountDetails)
        {
            Account account = _mapper.Map<Account>(accountDetails);

            AccountSaveStatus saveStatus = _accountManager.RegisterAccount(account);

            if (saveStatus.STATUS)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}

