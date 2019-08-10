using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Repositories;
using AgendaWeb.Models;
using AgendaWeb.Core.DI;

namespace AgendaWeb.Repositories.ResourceProfiles
{
    [AutoDIService]
    public interface IResourceProfileRepository : IRepository<ResourceProfile>
    {
    }
}
