using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Incidents.Application.Services;
using Incidents.Application.Validators;
using Incidents.Domain.Requests;
using Incidents.Helpers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Incidents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("accounts/create")]
        public async Task<IActionResult> CreateAccount([FromBody] AccountRequest request)
        {
            var validator = new AccountValidator();
            var validationResult = await ValidationHelper.ValidateRequest(request, validator);

            if (validationResult.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _accountService.CreateAccount(request);

            return ResponseHelper.ReturnResponse(response);
        }
    }
}
