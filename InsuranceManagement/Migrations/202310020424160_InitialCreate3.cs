namespace InsuranceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Account", "Role_RoleId", "dbo.Role");
            DropIndex("dbo.Account", new[] { "Role_RoleId" });
            DropColumn("dbo.Account", "RoleID");
            RenameColumn(table: "dbo.Account", name: "Role_RoleId", newName: "RoleId");
            AlterColumn("dbo.Account", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Account", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Account", "RoleId");
            AddForeignKey("dbo.Account", "RoleId", "dbo.Role", "RoleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Account", "RoleId", "dbo.Role");
            DropIndex("dbo.Account", new[] { "RoleId" });
            AlterColumn("dbo.Account", "RoleId", c => c.Int());
            AlterColumn("dbo.Account", "RoleId", c => c.String());
            RenameColumn(table: "dbo.Account", name: "RoleId", newName: "Role_RoleId");
            AddColumn("dbo.Account", "RoleID", c => c.String());
            CreateIndex("dbo.Account", "Role_RoleId");
            AddForeignKey("dbo.Account", "Role_RoleId", "dbo.Role", "RoleId");
        }
    }
}
