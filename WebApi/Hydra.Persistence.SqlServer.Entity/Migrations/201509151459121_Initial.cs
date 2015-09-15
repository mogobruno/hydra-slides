namespace Hydra.Persistence.SqlServer.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_slides",
                c => new
                    {
                        sld_id = c.Long(nullable: false, identity: true),
                        sld_title = c.String(nullable: false, maxLength: 100),
                        sld_sub_title = c.String(nullable: false, maxLength: 100),
                        sld_description = c.String(nullable: false, maxLength: 1000),
                        sld_content = c.String(nullable: false),
                        sld_theme = c.String(nullable: false),
                        sld_create_date = c.DateTime(nullable: false),
                        sld_update_date = c.DateTime(),
                        usr_owner_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.sld_id)
                .ForeignKey("dbo.tbl_users", t => t.usr_owner_id)
                .Index(t => t.usr_owner_id);
            
            CreateTable(
                "dbo.tbl_users",
                c => new
                    {
                        usr_id = c.Long(nullable: false, identity: true),
                        usr_name = c.String(nullable: false, maxLength: 200),
                        usr_email = c.String(nullable: false, maxLength: 200),
                        usr_password = c.String(nullable: false),
                        usr_nationationality = c.String(maxLength: 100),
                        usr_job = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.usr_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_slides", "usr_owner_id", "dbo.tbl_users");
            DropIndex("dbo.tbl_slides", new[] { "usr_owner_id" });
            DropTable("dbo.tbl_users");
            DropTable("dbo.tbl_slides");
        }
    }
}
