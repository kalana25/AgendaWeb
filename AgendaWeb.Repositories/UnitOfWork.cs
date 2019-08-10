using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Repositories.Styles;
using System.Threading.Tasks;
using AgendaWeb.DAL;


namespace AgendaWeb.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext context;
        public IStyleRepository Styles { get; private set; }

        public UnitOfWork(DataBaseContext context,IStyleRepository styleRepository)
        {
            this.context = context;
            this.Styles = styleRepository;
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
