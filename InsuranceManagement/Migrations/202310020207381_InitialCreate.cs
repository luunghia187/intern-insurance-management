namespace InsuranceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        AccountPassWork = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Agent",
                c => new
                    {
                        AgentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.AgentId);
            
            CreateTable(
                "dbo.Contract",
                c => new
                    {
                        ContractId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        AgentId = c.Int(nullable: false),
                        InsuranceId = c.Int(nullable: false),
                        SigningDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Proof = c.String(),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.Agent", t => t.AgentId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Insurance", t => t.InsuranceId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.AgentId)
                .Index(t => t.InsuranceId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Insurance",
                c => new
                    {
                        InsuranceId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        YearsOfPayment = c.Int(nullable: false),
                        PaymentPerYear = c.Int(nullable: false),
                        Refund = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InsuranceId);
            
            CreateTable(
                "dbo.InsuranceEvent",
                c => new
                    {
                        InsuranceEventId = c.Int(nullable: false, identity: true),
                        ContractId = c.Int(nullable: false),
                        Description = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        Refund = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InsuranceEventId)
                .ForeignKey("dbo.Contract", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InsuranceEvent", "ContractId", "dbo.Contract");
            DropForeignKey("dbo.Contract", "InsuranceId", "dbo.Insurance");
            DropForeignKey("dbo.Contract", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Contract", "AgentId", "dbo.Agent");
            DropIndex("dbo.InsuranceEvent", new[] { "ContractId" });
            DropIndex("dbo.Contract", new[] { "InsuranceId" });
            DropIndex("dbo.Contract", new[] { "AgentId" });
            DropIndex("dbo.Contract", new[] { "CustomerId" });
            DropTable("dbo.InsuranceEvent");
            DropTable("dbo.Insurance");
            DropTable("dbo.Customer");
            DropTable("dbo.Contract");
            DropTable("dbo.Agent");
            DropTable("dbo.Account");
        }
    }
}
