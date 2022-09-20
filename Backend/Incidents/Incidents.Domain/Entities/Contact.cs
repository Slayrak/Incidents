using System;
using System.Collections.Generic;
using System.Text;

namespace Incidents.Domain.Entities
{
    public class Contact : IEntity<long>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        #nullable enable
        public Account? Account { get; set; }
        #nullable disable
    }
}
