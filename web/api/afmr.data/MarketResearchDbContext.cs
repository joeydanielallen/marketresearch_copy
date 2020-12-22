using afmr.data.Models;
using afmr.data.Models.Security;
using afmr.data.Models.Template;
using afmr.data.Models.Vendors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data
{
    public class MarketResearchDbContext : DbContext
    {
        public MarketResearchDbContext(
            string connectionString)
            : base(GetOptions(connectionString))
        {
        }

        public DbSet<RecentUserVendor> RecentUserVendor { get; set; }
        public DbSet<SetAside> SetAside { get; set; }
        public DbSet<VendorPart> VendorPart { get; set; }
        public DbSet<VendorContact> VendorContact { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<TemplateInstanceAnswer> TemplateInstanceAnswer { get; set; }
        public DbSet<TemplateInitiateVendor> TemplateInitiateVendor { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<CustomSelectAnswer> CustomSelectAnswer { get; set; }
        public DbSet<QuestionType> QuestionType { get; set; }
        public DbSet<TemplateInstanceUser> TemplateInstanceUser { get; set; }
        public DbSet<TemplateSection> TemplateSection { get; set; }
        public DbSet<TemplateSectionGroup> TemplateSectionGroup { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<TemplateInstance> TemplateInstance { get; set; }
        public DbSet<TemplateSourceType> TemplateSourceType { get; set; }
        public DbSet<TemplateServiceType> TemplateServiceType { get; set; }
        public DbSet<TemplateOrg> TemplateOrg { get; set; }
        public DbSet<TemplateBidType> TemplateBidType { get; set; }
        public DbSet<Template> Template { get; set; }
        public DbSet<BidType> BidType { get; set; }
        public DbSet<ServiceType> ServiceType { get; set; }
        public DbSet<SourceType> SourceType { get; set; }
        public DbSet<UserOrg> UserOrg { get; set; }
        public DbSet<Org> Org { get; set; }
        public DbSet<MaterialMgmtAggregateCode> MaterialMgmtAggregateCode { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<RoleClaim> RoleClaim { get; set; }
        public DbSet<PermissionClaim> PermissionClaim { get; set; }
        public DbSet<AppRole> AppRole { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    base.OnModelCreating(modelBuilder);
        //}

        private static DbContextOptions GetOptions(
            string connectionString)
        {
            return SqlServerDbContextOptionsExtensions
                .UseSqlServer(
                new DbContextOptionsBuilder(),
                connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
        }
    }
}
