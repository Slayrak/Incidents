using System;
using System.Collections.Generic;
using System.Text;

namespace Incidents.Domain.Entities
{
    public class Account
    {
        public long Id { get; set; }
        public string AccountName { get; set; }
        public ICollection<Contact> Contacts { get; set; }

#nullable enable
        public Incident? Incident { get; set; }
#nullable disable
    }
}
