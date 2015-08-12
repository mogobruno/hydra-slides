namespace Hydra.Persistence.MySql.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoLinkUserSlide : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_slides", "usr_owner_id", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_slides", "usr_owner_id");
            AddForeignKey("dbo.tbl_slides", "usr_owner_id", "dbo.tbl_users", "usr_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_slides", "usr_owner_id", "dbo.tbl_users");
            DropIndex("dbo.tbl_slides", new[] { "usr_owner_id" });
            DropColumn("dbo.tbl_slides", "usr_owner_id");
        }
    }
}
