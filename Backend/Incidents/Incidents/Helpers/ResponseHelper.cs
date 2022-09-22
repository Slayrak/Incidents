using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Incidents.Domain.Responces;

using Microsoft.AspNetCore.Mvc;

namespace Incidents.Helpers
{
    public class ResponseHelper
    {
        public static IActionResult ReturnResponse<T>(OperationResponse<T> response) where T : class
        {
            return response.Result switch
            {
                OperationResult.Failure => new BadRequestObjectResult(response.Error),
                OperationResult.NotFound => new NotFoundObjectResult(response.Error),
                OperationResult.Success => new OkObjectResult(response.Model),
                _ => throw new NotSupportedException(),
            };
        }
    }
}
