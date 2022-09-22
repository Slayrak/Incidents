using System;
using System.Collections.Generic;
using System.Text;

using FluentValidation;

using Incidents.Domain.Requests;

namespace Incidents.Application.Validators
{
    public class IncidentValidator : AbstractValidator<IncidentRequest>
    {
        public IncidentValidator()
        {
            RuleFor(x => x.AccountName)
               .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage(x => $"'{x.Email}' is not a valid email address.");

            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();
        }
    }
}
