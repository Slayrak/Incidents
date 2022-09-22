using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Incidents.Domain.Entities;
using Incidents.Domain.Interfaces;
using Incidents.Domain.Requests;
using Incidents.Domain.Responces;
using Incidents.Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace Incidents.Application.Services
{
    public class ContactService
    {
        private readonly IncidentsDbContext _context;

        public ContactService(IncidentsDbContext incidentsDbContext)
        {
            _context = incidentsDbContext;
        }

        public async Task<OperationResponse<Contact>> CreateContact(ContactRequest request)
        {
            var contact = new Contact
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };

            if((await _context.Contacts.FirstOrDefaultAsync(x => x.Email == contact.Email)) is null)
            {
                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();

                return new OperationResponse<Contact>(contact, OperationResult.Success);
            }

            return new OperationResponse<Contact>(contact, OperationResult.Failure, "There is such a contact already");
        }

    }
}
