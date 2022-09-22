using System;
using System.Collections.Generic;
using System.Text;

namespace Incidents.Domain.Requests
{
    public class IncidentRequest
    {
        public string AccountName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }
    }
}
