namespace webERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.R_User_Role", "ActionInfo_Id", "dbo.ActionInfoes");
            DropForeignKey("dbo.UserActionGroups", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserActionGroups", "ActionGroup_Id", "dbo.ActionGroups");
            DropIndex("dbo.R_User_Role", new[] { "ActionInfo_Id" });
            DropIndex("dbo.UserActionGroups", new[] { "User_Id" });
            DropIndex("dbo.UserActionGroups", new[] { "ActionGroup_Id" });
            CreateTable(
                "dbo.ActionGroupUsers",
                c => new
                    {
                        ActionGroup_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ActionGroup_Id, t.User_Id })
                .ForeignKey("dbo.ActionGroups", t => t.ActionGroup_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.ActionGroup_Id)
                .Index(t => t.User_Id);
            
            DropColumn("dbo.R_User_Role", "ActionInfo_Id");
            DropTable("dbo.UserActionGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserActionGroups",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        ActionGroup_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.ActionGroup_Id });
            
            AddColumn("dbo.R_User_Role", "ActionInfo_Id", c => c.Int());
            DropIndex("dbo.ActionGroupUsers", new[] { "User_Id" });
            DropIndex("dbo.ActionGroupUsers", new[] { "ActionGroup_Id" });
            DropForeignKey("dbo.ActionGroupUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.ActionGroupUsers", "ActionGroup_Id", "dbo.ActionGroups");
            DropTable("dbo.ActionGroupUsers");
            CreateIndex("dbo.UserActionGroups", "ActionGroup_Id");
            CreateIndex("dbo.UserActionGroups", "User_Id");
            CreateIndex("dbo.R_User_Role", "ActionInfo_Id");
            AddForeignKey("dbo.UserActionGroups", "ActionGroup_Id", "dbo.ActionGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserActionGroups", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.R_User_Role", "ActionInfo_Id", "dbo.ActionInfoes", "Id");
        }
    }
}
