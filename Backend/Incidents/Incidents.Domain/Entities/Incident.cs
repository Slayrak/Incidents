using System;
using System.Collections.Generic;
using System.Text;

namespace Incidents.Domain.Entities
{
    public class Incident
    {
        public string IncidentName { get; set; }
        public string Description { get; set; } 
        
        public ICollection<Account> Accounts { get; set; }
    }
}
