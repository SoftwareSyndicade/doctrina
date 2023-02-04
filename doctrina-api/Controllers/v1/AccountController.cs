using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using doctrine_api.Constants;
using doctrine_api.DataModels;
using doctrine_api.Management.Account;
using doctrine_api.Management.Account.Models;
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


        [HttpPost(CRUDActions.REGISTER)]
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

        [HttpGet(CRUDActions.FETCH)]
        public IActionResult Fetch(String accountID)
        {
            var account = _accountManager.GetAccount(accountID);

            if (account == null)
                return BadRequest("Account not found.");

            return Ok(account);
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

