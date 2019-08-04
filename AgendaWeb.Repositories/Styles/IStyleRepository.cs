using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Models;
using System.Threading.Tasks;
using AgendaWeb.Core.DI;

namespace AgendaWeb.Repositories.Styles
{
    [AutoDIService]
    public interface IStyleRepository : IRepository<Style>
    {
        Task<IEnumerable<Style>> GetCustomStyles(bool customStyle);
        Task<IEnumerable<Style>> GetStylesWithServices(int pageIndex, int pageSize);
    }
}
