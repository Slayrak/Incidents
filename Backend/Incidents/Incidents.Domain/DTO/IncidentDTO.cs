using System;
using System.Collections.Generic;
using System.Text;

namespace Incidents.Domain.DTO
{
    public class IncidentDTO
    {
        public long Id { get; set; }
        public string IncidentName { get; set; }
        public ICollection<AccountDTO> Accounts { get; set; }
    }
}
