namespace Hydra.Persistence.MySql.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoSlide : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_slides",
                c => new
                    {
                        sld_id = c.Long(nullable: false, identity: true),
                        sld_title = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        sld_description = c.String(nullable: false, maxLength: 1000, storeType: "nvarchar"),
                        sld_content = c.String(nullable: false, unicode: false),
                        sld_create_date = c.DateTime(nullable: false, precision: 0, defaultValueSql:"now()"),
                        sld_update_date = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.sld_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_slides");
        }
    }
}
