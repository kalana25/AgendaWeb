using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AgendaWeb.Models;

namespace AgendaWeb.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<ResourcePlan> ResourcePlans { get; set; }
        public DbSet<ResourceProfile> ResourceProfiles { get; set; }
        public DbSet<ResourcePlanProfile> ResourcePlanProfiles { get; set; }
    }
}
