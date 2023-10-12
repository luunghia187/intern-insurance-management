namespace InsuranceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agent", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Agent", "Phone", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Agent", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Agent", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.Insurance", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Insurance", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Insurance", "Description", c => c.String());
            AlterColumn("dbo.Insurance", "Name", c => c.String());
            AlterColumn("dbo.Customer", "Mail", c => c.String());
            AlterColumn("dbo.Customer", "Address", c => c.String());
            AlterColumn("dbo.Customer", "Phone", c => c.String());
            AlterColumn("dbo.Customer", "Name", c => c.String());
            AlterColumn("dbo.Agent", "Mail", c => c.String());
            AlterColumn("dbo.Agent", "Address", c => c.String());
            AlterColumn("dbo.Agent", "Phone", c => c.String());
            AlterColumn("dbo.Agent", "Name", c => c.String());
        }
    }
}
