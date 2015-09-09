namespace Hydra.Persistence.MySql.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NationalityIsnotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_users", "usr_nationationality", c => c.String(maxLength: 100, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_users", "usr_nationationality", c => c.String(nullable: false, maxLength: 100, storeType: "nvarchar"));
        }
    }
}
