using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AgendaWeb.Repositories.Styles;
using AgendaWeb.Core.DI;


namespace AgendaWeb.Repositories
{
    [AutoDIService(implementationType: "AgendaWeb.Repositories.UnitOfWork")]
    public interface IUnitOfWork : IDisposable
    {
        IStyleRepository Styles { get; }
        Task<int> Complete();
    }
}
