namespace InsuranceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            //Sql("ALTER TABLE Contract ALTER COLUMN Status ContractStatus");
        }
        
        public override void Down()
        {
            //Sql("ALTER TABLE Contract ALTER COLUMN Status int");
        }
    }
}
