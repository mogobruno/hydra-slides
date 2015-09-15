using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hydra.Domain;
using Hydra.Persistence.SqlServer.Entity.TypeConfigurations;
using Hydra.Persistence.SqlServer.Entity.Migrations;

namespace Hydra.Persistence.SqlServer.Entity.Context
{
    public class HydraDbContext: DbContext
    {
        public DbSet<Slide> Slides { get; set; }
        public DbSet<User> Users { get; set; }

        public HydraDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HydraDbContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SlideTypeConfiguration());
            modelBuilder.Configurations.Add(new UserTypeConfiguration());
        }
    }
}
