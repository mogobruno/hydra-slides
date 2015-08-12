using Hydra.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Persistence.MySql.Entity.TypeConfigurations
{
    class UserTypeConfiguration : AbstractTypeConfiguration<User>
    {
        public override void ConfigureTableName()
        {
            ToTable("tbl_users");
        }

        public override void ConfigureFields()
        {
            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("usr_id")
                .HasColumnOrder(0)
                .IsRequired();

            Property(p => p.Name)
                .HasColumnName("usr_name")
                .HasMaxLength(200)
                .HasColumnOrder(1)
                .IsRequired();

            Property(p => p.Email)
                .HasColumnName("usr_email")
                .HasMaxLength(200)
                .HasColumnOrder(2)
                .IsRequired();

            Property(p => p.Password)
                .HasColumnName("usr_password")
                .HasColumnOrder(3)
                .IsRequired();

            Property(p => p.Nationality)
                .HasColumnName("usr_nationationality")
                .HasMaxLength(100)
                .HasColumnOrder(4)
                .IsRequired();

            Property(p => p.Job)
                .HasColumnName("usr_job")
                .HasMaxLength(100)
                .HasColumnOrder(5)
                .IsOptional();
        }

        public override void ConfigurePrimaryKey()
        {
            HasKey(pk => pk.Id);
        }

        public override void ConfigureForeignKeys()
        {
            HasMany(p => p.Slides)
                .WithRequired(p => p.Owner)
                .HasForeignKey(p => p.OwnerId)
                .WillCascadeOnDelete(false);
        }

        public override void ConfigureOthers()
        {
            
        }
    }
}
