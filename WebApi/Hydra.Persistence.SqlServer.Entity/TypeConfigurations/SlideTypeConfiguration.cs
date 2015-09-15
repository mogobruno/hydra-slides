using Hydra.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydra.Persistence.SqlServer.Entity.TypeConfigurations
{
    class SlideTypeConfiguration : AbstractTypeConfiguration<Slide>
    {
        public override void ConfigureTableName()
        {
            ToTable("tbl_slides");
        }

        public override void ConfigureFields()
        {
            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("sld_id")
                .HasColumnOrder(0)
                .IsRequired();

            Property(p => p.Title)
                .HasColumnName("sld_title")
                .HasMaxLength(100)
                .HasColumnOrder(1)
                .IsRequired();

            Property(p => p.SubTitle)
                .HasColumnName("sld_sub_title")
                .HasMaxLength(100)
                .HasColumnOrder(2)
                .IsRequired();

            Property(p => p.Description)
                .HasColumnName("sld_description")
                .HasMaxLength(1000)
                .HasColumnOrder(3)
                .IsRequired();

            Property(p => p.Content)
                .HasColumnName("sld_content")
                .HasColumnOrder(4)
                .IsRequired();

            Property(p => p.Theme)
                .HasColumnName("sld_theme")
                .HasColumnOrder(5)
                .IsRequired();

            Property(p => p.CreateDate)
                .HasColumnName("sld_create_date")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                .HasColumnOrder(6)
                .IsRequired();

            Property(p => p.UpdateDate)
                .HasColumnName("sld_update_date")
                .HasColumnOrder(7)
                .IsOptional();

            Property(p => p.OwnerId)
                .HasColumnName("usr_owner_id")
                .HasColumnOrder(8)
                .IsRequired();
        }

        public override void ConfigurePrimaryKey()
        {
            HasKey(pk => pk.Id);
        }

        public override void ConfigureForeignKeys()
        {

        }

        public override void ConfigureOthers()
        {

        }
    }
}
