namespace Hydra.Persistence.MySql.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoPropriedadeSubTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_slides", "sld_sub_title", c => c.String(nullable: false, maxLength: 100, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_slides", "sld_sub_title");
        }
    }
}
