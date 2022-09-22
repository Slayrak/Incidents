using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Incidents.Domain.Entities;

namespace Incidents.Domain.Interfaces.Repository
{
    public interface IContactRepository : IRepository<Contact, long>
    {
        Task<Contact> GetContactByEmail(string email);
    }
}
