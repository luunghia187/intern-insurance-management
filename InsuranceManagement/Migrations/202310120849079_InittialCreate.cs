namespace InsuranceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InittialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contract", "SigningDate", c => c.DateTime());
            AlterColumn("dbo.Contract", "ExpirationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contract", "ExpirationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contract", "SigningDate", c => c.DateTime(nullable: false));
        }
    }
}
