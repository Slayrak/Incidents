using System;
using System.Collections.Generic;
using System.Text;

using FluentValidation;

using Incidents.Domain.Requests;

namespace Incidents.Application.Validators
{
    public class AccountValidator : AbstractValidator<AccountRequest>
    {
        public AccountValidator()
        {
            RuleFor(x => x.ContactEmail)
                .EmailAddress()
                .WithMessage(x => $"'{x.ContactEmail}' is not a valid email address.");

            RuleFor(x => x.AccountName)
                .NotEmpty();
        }
    }
}
