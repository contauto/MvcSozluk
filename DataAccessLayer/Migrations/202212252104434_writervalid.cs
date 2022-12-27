namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class writervalid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "WriterName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Writers", "WriterSurname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterSurname", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterName", c => c.String(maxLength: 50));
        }
    }
}
