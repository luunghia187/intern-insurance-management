namespace InsuranceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InittialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contract", "SigningDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Contract", "ExpirationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.InsuranceEvent", "EventDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InsuranceEvent", "EventDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contract", "ExpirationDate", c => c.DateTime());
            AlterColumn("dbo.Contract", "SigningDate", c => c.DateTime());
        }
    }
}
