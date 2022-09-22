using System;
using System.Collections.Generic;
using System.Text;

namespace Incidents.Domain.Requests
{
    public class AccountRequest
    {
        public string AccountName { get; set; }

        public string ContactEmail { get; set; }
    }
}
