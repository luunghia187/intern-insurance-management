namespace InsuranceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "AccountName", c => c.String(nullable: false));
            AlterColumn("dbo.Account", "AccountPassWork", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Account", "AccountPassWork", c => c.String());
            AlterColumn("dbo.Account", "AccountName", c => c.String());
        }
    }
}
