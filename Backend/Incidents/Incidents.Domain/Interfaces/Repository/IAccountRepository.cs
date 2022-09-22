using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Incidents.Domain.Entities;

namespace Incidents.Domain.Interfaces.Repository
{
    public interface IAccountRepository : IRepository<Account, long>
    {
        Task<Account> GetAccountByName(string name); 
    }
}
