using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AgendaWeb.Models;
using AgendaWeb.DAL;
using System.Threading.Tasks;

namespace AgendaWeb.Repositories.ResourcePlans
{
    public class ResourcePlanRepository : Repository<ResourcePlan>, IResourcePlanRepository
    {
        public ResourcePlanRepository(DataBaseContext context):base(context)
        {

        }

        public async Task<IEnumerable<ResourcePlan>> GetAllResourcePlanWithProfiles()
        {
            return await DatabaseContext.ResourcePlans
                .Include(p => p.PlanProfiles)
                .ThenInclude(pp=>pp.ResourceProfile)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public Task<IEnumerable<ResourcePlan>> GetPaginatedResourcePlanWithProfiles(int pageIndex, int pageSize)
        {
            //return await DatabaseContext.ResourcePlans
            //    .Include(p => p.PlanProfiles)
            //    .OrderBy(s => s.Name)
            //    .Skip((pageIndex - 1) * pageSize)
            //    .Take(pageSize)
            //    .ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<ResourcePlan> GetResourcePlanWithProfiles(int id)
        {
            return await DatabaseContext.ResourcePlans
                .Include(p => p.PlanProfiles)
                .ThenInclude(pp => pp.ResourceProfile)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
