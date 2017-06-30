namespace GJBCTest.Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "Title", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Albums", "Title", c => c.String(nullable: false, maxLength: 2));
        }
    }
}
