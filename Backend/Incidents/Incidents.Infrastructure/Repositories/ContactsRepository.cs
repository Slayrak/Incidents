using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Incidents.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Incidents.Infrastructure.Repositories
{
    public class ContactsRepository : Repository<Contact, long>
    {
        public ContactsRepository(IncidentsDbContext context)
            : base(context)
        { }

        public async Task<Contact> GetContactByEmail(string email)
        {
            return await _dbContext
                .Set<Contact>()
                .Include(x => x.Account)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

    }
}
