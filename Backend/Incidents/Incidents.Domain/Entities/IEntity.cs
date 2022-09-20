using System;
using System.Collections.Generic;
using System.Text;

namespace Incidents.Domain.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
