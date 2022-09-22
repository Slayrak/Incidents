using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Incidents.Domain.Entities;
using Incidents.Domain.Requests;
using Incidents.Domain.Responces;
using Incidents.Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Services
{
    public class AccountService
    {
        private readonly IncidentsDbContext _context;

        public AccountService(IncidentsDbContext incidentsDbContext)
        {
            _context = incidentsDbContext;
        }

        public async Task<OperationResponse<Account>> CreateAccount(AccountRequest request)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Email == request.ContactEmail);

            if (!(contact is null))
            {
                if ((await _context.Accounts.FirstOrDefaultAsync(x => x.AccountName == request.AccountName)) is null)
                {
                    var account = new Account { AccountName = request.AccountName };

                    await _context.Accounts.AddAsync(account);
                    contact.Account = account;
                    await _context.SaveChangesAsync();

                    return new OperationResponse<Account>(account, OperationResult.Success, "");
                }

                return new OperationResponse<Account>(null, OperationResult.Failure, "Account with this name already exists.");
            }

            return new OperationResponse<Account>(null, OperationResult.NotFound, "There is no such account");
        }

    }
}
