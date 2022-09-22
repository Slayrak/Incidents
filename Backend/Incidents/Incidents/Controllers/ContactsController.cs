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
    public class ContactsController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("contacts/create")]
        public async Task<IActionResult> CreateContact([FromBody] ContactRequest request)
        {
            var validator = new ContactValidator();
            var validationResult = await ValidationHelper.ValidateRequest(request, validator);

            if (validationResult.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _contactService.CreateContact(request);

            return ResponseHelper.ReturnResponse(response);
        }
    }
}
