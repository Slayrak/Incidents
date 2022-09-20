using System;
using System.Collections.Generic;
using System.Text;

using Incidents.Domain.Entities;

namespace Incidents.Domain.Interfaces.Repository
{
    public interface IIncidentRepository : IRepository<Incident, long>
    {
    }
}
