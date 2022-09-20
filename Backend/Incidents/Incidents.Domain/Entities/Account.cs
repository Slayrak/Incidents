using System;
using System.Collections.Generic;
using System.Text;

namespace Incidents.Domain.Entities
{
    public class Account : IEntity<int>
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public ICollection<Contact> Contacts { get; set; }

        public Incident Incident { get; set; }
    }
}
