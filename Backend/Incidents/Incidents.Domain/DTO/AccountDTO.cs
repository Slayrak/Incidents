using System;
using System.Collections.Generic;
using System.Text;

namespace Incidents.Domain.DTO
{
    public class AccountDTO
    {
        public long Id { get; set; }
        public string AccountName { get; set; }

#nullable enable
        public IncidentDTO? Incident { get; set; }
#nullable disable
        public ICollection<ContactDTO> Contacts { get; set; }
    }
}
