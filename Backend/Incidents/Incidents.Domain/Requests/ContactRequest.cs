using System;
using System.Collections.Generic;
using System.Text;

namespace Incidents.Domain.Requests
{
    public class ContactRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
