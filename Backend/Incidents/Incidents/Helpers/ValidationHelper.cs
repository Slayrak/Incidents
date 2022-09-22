using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using FluentValidation;

using Incidents.Domain.Responces;

namespace Incidents.Helpers
{
    public class ValidationHelper
    {
        public static async Task<ValidationResponse> ValidateRequest<T>(T request, AbstractValidator<T> validator)
        {
            var result = new ValidationResponse();

            if (!(await validator.ValidateAsync(request)).IsValid)
            {
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Errors = (await validator
                    .ValidateAsync(request))
                    .Errors
                    .Select(x => x.ErrorMessage)
                    .Aggregate((x, y) => $"{x}\n{y}");
            }

            return result;
        }
    }
}
