using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AgendaWeb.Models;
using AgendaWeb.DAL;
using System.Threading.Tasks;

namespace AgendaWeb.Repositories.Resources
{
    public class ResourceRepository : Repository<Resource>,IResourceRepository
    {
        public ResourceRepository(DbContext context):base(context)
        {

        }

        public void Delete(Resource resourcePlan)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Resource>> GetAllResourceWithFullInfo()
        {
            return await DatabaseContext.Resources
                .Include(r => r.Style)
                .Include(r => r.Collaborator)
                .Include(r => r.ResourceResourceProfiles)
                .ThenInclude(rp => rp.ResourceProfile)
                .ToListAsync();
        }

        public async Task<IEnumerable<Resource>> GetPaginatedResourceWithFullInfo(int pageIndex, int pageSize)
        {
            return await DatabaseContext.Resources
                .Include(r => r.Style)
                .Include(r => r.Collaborator)
                .Include(r => r.ResourceResourceProfiles)
                .ThenInclude(rp => rp.ResourceProfile)
                .OrderBy(s => s.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Resource> GetResourceWithFullInfo(int id)
        {
            return await DatabaseContext.Resources
                .Include(r => r.Style)
                .Include(r => r.Collaborator)
                .Include(r => r.ResourceResourceProfiles)
                .ThenInclude(rp => rp.ResourceProfile)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
