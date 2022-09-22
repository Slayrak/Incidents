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
    public class IncidentController : ControllerBase
    {
        private readonly IncidentService _incidentService;

        public IncidentController(IncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpPost("incidents/create")]
        public async Task<IActionResult> CreateIncident([FromBody] IncidentRequest request)
        {
            var validator = new IncidentValidator();
            var validationResult = await ValidationHelper.ValidateRequest(request, validator);

            if (validationResult.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _incidentService.CreateIncident(request);

            return ResponseHelper.ReturnResponse(response);
        }
    }
}
