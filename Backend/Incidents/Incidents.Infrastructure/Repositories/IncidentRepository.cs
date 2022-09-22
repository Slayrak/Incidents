using System;
using System.Collections.Generic;
using System.Text;

using Incidents.Domain.Entities;

namespace Incidents.Infrastructure.Repositories
{
    public class IncidentRepository : Repository<Incident, long>
    {
        public IncidentRepository(IncidentsDbContext context)
            :base(context)
        { }

    }
}
