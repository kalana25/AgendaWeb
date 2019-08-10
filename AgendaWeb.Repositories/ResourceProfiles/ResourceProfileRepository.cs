using System;
using System.Collections.Generic;
using System.Text;
using AgendaWeb.Models;
using AgendaWeb.DAL;

namespace AgendaWeb.Repositories.ResourceProfiles
{
    public class ResourceProfileRepository:Repository<ResourceProfile>,IResourceProfileRepository
    {
        public ResourceProfileRepository(DataBaseContext contex):base(contex)
        {

        }
    }
}
