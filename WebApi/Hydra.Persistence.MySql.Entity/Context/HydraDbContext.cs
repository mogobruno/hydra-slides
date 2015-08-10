using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Entity;
using Hydra.Domain;
using Hydra.Persistence.MySql.Entity.Migrations;
using Hydra.Persistence.MySql.Entity.TypeConfigurations;

namespace Hydra.Persistence.MySql.Entity.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class HydraDbContext: DbContext
    {
        public DbSet<Slide> Slides { get; set; }
        public DbSet<User> Users { get; set; }

        public HydraDbContext()
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
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
