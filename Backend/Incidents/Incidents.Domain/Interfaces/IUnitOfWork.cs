using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Incidents.Domain.Interfaces
{
    public interface IUnitOfWork<TId>
    {
        TRepository GetRepository<TRepository>();
        void RegisterRepositories(Assembly interfaceAssembly, Assembly implementationAssembly);

        Task Save();
    }
}
