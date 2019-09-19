using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Repositories;
using System.Threading.Tasks;
using AgendaWeb.Models;
using AgendaWeb.Core.DI;

namespace AgendaWeb.Repositories.Resources
{
    [AutoDIService]
    public interface IResourceRepository : IRepository<Resource>
    {
        Task<IEnumerable<Resource>> GetAllResourceWithFullInfo();
        Task<Resource> GetResourceWithFullInfo(int id);
        Task<IEnumerable<Resource>> GetPaginatedResourceWithFullInfo(int pageIndex, int pageSize);
        void Delete(Resource resourcePlan);
    }
}
