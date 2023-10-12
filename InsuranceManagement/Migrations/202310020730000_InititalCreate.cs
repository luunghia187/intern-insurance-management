namespace InsuranceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InititalCreate : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Agent", "AccountID");
            CreateIndex("dbo.Customer", "AccountID");
            AddForeignKey("dbo.Agent", "AccountID", "dbo.Account", "AccountId");
            AddForeignKey("dbo.Customer", "AccountID", "dbo.Account", "AccountId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "AccountID", "dbo.Account");
            DropForeignKey("dbo.Agent", "AccountID", "dbo.Account");
            DropIndex("dbo.Customer", new[] { "AccountID" });
            DropIndex("dbo.Agent", new[] { "AccountID" });
        }
    }
}
