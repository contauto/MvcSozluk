namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rememberme1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Writers", "RememberMe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "RememberMe", c => c.Boolean(nullable: false));
        }
    }
}
