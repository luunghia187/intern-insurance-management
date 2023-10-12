namespace InsuranceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InititalCreate1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Agent", new[] { "AccountID" });
            DropIndex("dbo.Customer", new[] { "AccountID" });
            CreateIndex("dbo.Agent", "AccountId");
            CreateIndex("dbo.Customer", "AccountId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customer", new[] { "AccountId" });
            DropIndex("dbo.Agent", new[] { "AccountId" });
            CreateIndex("dbo.Customer", "AccountID");
            CreateIndex("dbo.Agent", "AccountID");
        }
    }
}
