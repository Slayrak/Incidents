using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Incidents.Domain.Entities;
using Incidents.Domain.Requests;
using Incidents.Domain.Responces;
using Incidents.Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Services
{
    public class IncidentService
    {
        private readonly IncidentsDbContext _context;

        public IncidentService(IncidentsDbContext incidentsDbContext)
        {
            _context = incidentsDbContext;
        }

        public async Task<OperationResponse<Incident>> CreateIncident(IncidentRequest request)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountName == request.AccountName);
            var contact = new Contact { Email = request.Email, FirstName = request.FirstName, LastName = request.LastName };
            var incident = new Incident { Description = request.Description, IncidentName = Guid.NewGuid().ToString() };

            if(!(account is null))
            {
                var checkContact = await _context.Contacts.FirstOrDefaultAsync(x => x.Email == request.Email);

                if (checkContact is null)
                {
                    contact.Account = account;
                    await _context.Contacts.AddAsync(contact);
                    checkContact = contact;
                }
                
                if (checkContact.FirstName == contact.FirstName && checkContact.LastName == contact.LastName)
                {
                    await _context.Incidents.AddAsync(incident);
                    account.Incident = incident;

                    await _context.SaveChangesAsync();

                    return new OperationResponse<Incident>(incident, OperationResult.Success);
                }

                return new OperationResponse<Incident>(null, OperationResult.Failure, "Incorect contact data");
            }


            return new OperationResponse<Incident>(null, OperationResult.NotFound, "There is no such account");
        }


    }
}
