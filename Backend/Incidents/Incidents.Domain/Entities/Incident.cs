﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Incidents.Domain.Entities
{
    public class Incident : IEntity<int>
    {
        public int Id { get; set; }
        public string IncidentName { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
