using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Incidents.Domain.Entities;
using System.Threading.Tasks;

namespace Incidents.Infrastructure.Repositories
{
    public class AccountRepository : Repository<Account, long>
    {
        public AccountRepository(IncidentsDbContext context)
            :base(context)
        {}

        public async Task<Account> GetAccountByName(string name)
        {
            return await _dbContext
                .Set<Account>()
                .Include(x => x.Contacts)
                .FirstOrDefaultAsync(x => x.AccountName == name);
        }
    }
}
