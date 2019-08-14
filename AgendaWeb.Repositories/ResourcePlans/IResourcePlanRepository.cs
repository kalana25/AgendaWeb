using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Repositories;
using System.Threading.Tasks;
using AgendaWeb.Models;
using AgendaWeb.Core.DI;

namespace AgendaWeb.Repositories.ResourcePlans
{
    [AutoDIService]
    public interface IResourcePlanRepository : IRepository<ResourcePlan>
    {
        Task<IEnumerable<ResourcePlan>> GetAllResourcePlanWithProfiles();
        Task<ResourcePlan> GetResourcePlanWithProfiles(int id);
        Task<IEnumerable<ResourcePlan>> GetPaginatedResourcePlanWithProfiles(int pageIndex, int pageSize);
        void Delete(ResourcePlan resourcePlan);
    }
}
