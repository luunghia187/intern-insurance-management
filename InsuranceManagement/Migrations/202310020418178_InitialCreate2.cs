namespace InsuranceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.Account", "RoleID", c => c.String());
            AddColumn("dbo.Account", "Role_RoleId", c => c.Int());
            AddColumn("dbo.Agent", "AccountID", c => c.Int(nullable: false));
            AddColumn("dbo.Contract", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "AccountID", c => c.Int(nullable: false));
            AlterColumn("dbo.Insurance", "PaymentPerYear", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Insurance", "Refund", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.InsuranceEvent", "Refund", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Account", "Role_RoleId");
            AddForeignKey("dbo.Account", "Role_RoleId", "dbo.Role", "RoleId");
            DropColumn("dbo.Account", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Account", "Role", c => c.String());
            DropForeignKey("dbo.Account", "Role_RoleId", "dbo.Role");
            DropIndex("dbo.Account", new[] { "Role_RoleId" });
            AlterColumn("dbo.InsuranceEvent", "Refund", c => c.Int(nullable: false));
            AlterColumn("dbo.Insurance", "Refund", c => c.Int(nullable: false));
            AlterColumn("dbo.Insurance", "PaymentPerYear", c => c.Int(nullable: false));
            DropColumn("dbo.Customer", "AccountID");
            DropColumn("dbo.Contract", "Status");
            DropColumn("dbo.Agent", "AccountID");
            DropColumn("dbo.Account", "Role_RoleId");
            DropColumn("dbo.Account", "RoleID");
            DropTable("dbo.Role");
        }
    }
}
