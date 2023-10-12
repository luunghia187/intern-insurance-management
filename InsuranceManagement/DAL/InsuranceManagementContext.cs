using InsuranceManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace InsuranceManagement.DAL
{
    public class InsuranceManagementContext : DbContext
    {
        public InsuranceManagementContext() : base("InsuranceManagementContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Custommers { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<InsuranceEvent> InsuranceEvents { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Customer>()
                .HasRequired(c => c.Account)
                .WithMany()
                .HasForeignKey(c => c.AccountId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Agent>()
                .HasRequired(c => c.Account)
                .WithMany()
                .HasForeignKey(c => c.AccountId)
                .WillCascadeOnDelete(false);
        }
    }
}