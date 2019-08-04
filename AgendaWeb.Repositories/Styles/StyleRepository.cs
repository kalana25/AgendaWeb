using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AgendaWeb.Models;
using System.Threading.Tasks;
using AgendaWeb.DAL;
using Microsoft.EntityFrameworkCore;

namespace AgendaWeb.Repositories.Styles
{
    public class StyleRepository : Repository<Style>, IStyleRepository
    {
        public StyleRepository(DataBaseContext context) : base(context)
        {

        }



        public async Task<IEnumerable<Style>> GetCustomStyles(bool customStyle)
        {
            return await DatabaseContext.Styles
                .Include(s => s.Services)
                .Where(x => x.CustomStyle == customStyle)
                .ToListAsync();
        }

        public async Task<IEnumerable<Style>> GetStylesWithServices(int pageIndex, int pageSize)
        {
            return await DatabaseContext.Styles
                .Include(s => s.Services)
                .OrderBy(s => s.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
