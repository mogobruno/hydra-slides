namespace Hydra.Persistence.MySql.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoPropriedadeTema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_slides", "sld_theme", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_slides", "sld_theme");
        }
    }
}
