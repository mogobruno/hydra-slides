namespace Hydra.Persistence.MySql.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_users",
                c => new
                    {
                        usr_id = c.Int(nullable: false, identity: true),
                        usr_name = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        usr_email = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        usr_password = c.String(nullable: false, unicode: false),
                        usr_nationationality = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        usr_job = c.String(maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.usr_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_users");
        }
    }
}
