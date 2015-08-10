using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Persistence.MySql.Entity.TypeConfigurations
{
    abstract class AbstractTypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public AbstractTypeConfiguration()
        {
            ConfigureTableName();
            ConfigureFields();
            ConfigurePrimaryKey();
            ConfigureForeignKeys();
            ConfigureOthers();
        }

        public abstract void ConfigureTableName();
        public abstract void ConfigureFields();
        public abstract void ConfigurePrimaryKey();
        public abstract void ConfigureForeignKeys();
        public abstract void ConfigureOthers();
    }
}
