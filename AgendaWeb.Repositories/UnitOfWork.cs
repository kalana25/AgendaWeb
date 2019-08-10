using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Repositories.Styles;
using AgendaWeb.Repositories.ResourceProfiles;
using System.Threading.Tasks;
using AgendaWeb.DAL;


namespace AgendaWeb.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext context;
        public IStyleRepository Styles { get; private set; }
        public IResourceProfileRepository ResourceProfile { get; set; }

        public UnitOfWork(DataBaseContext context,
            IStyleRepository styleRepository,
            IResourceProfileRepository resourceProfileRepository)
        {
            this.context = context;
            this.Styles = styleRepository;
            this.ResourceProfile = resourceProfileRepository;
        }

        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
