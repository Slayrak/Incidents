using System;
using System.Collections.Generic;
using System.Text;

namespace Incidents.Domain.DTO
{
    public class ContactDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

#nullable enable
        public AccountDTO? Account { get; set; }
#nullable disable
    }
}
