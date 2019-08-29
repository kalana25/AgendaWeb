using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AgendaWeb.Repositories.Styles;
using AgendaWeb.Repositories.ResourceProfiles;
using AgendaWeb.Repositories.ResourcePlans;
using AgendaWeb.Repositories.Patients;
using AgendaWeb.Core.DI;


namespace AgendaWeb.Repositories
{
    [AutoDIService(implementationType: "AgendaWeb.Repositories.UnitOfWork")]
    public interface IUnitOfWork : IDisposable
    {
        IStyleRepository Styles { get; }
        IResourceProfileRepository ResourceProfile { get; }
        IResourcePlanRepository ResourcePlans { get; }
        IPatientRepository Patients { get; }
        Task<int> Complete();
    }
}
