using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class SmpcDbContext : DbContext
    {
        public SmpcDbContext() { }
        public SmpcDbContext(DbContextOptions<SmpcDbContext> options) : base(options) { }

        public virtual DbSet<SmpcOrganigram> SmpcOrganigrams { get; set; }
        public virtual DbSet<SmpcRole> SmpcRoles { get; set; }
        public virtual DbSet<SmpcMeasure> SmpcMeasures { get; set; }
        public virtual DbSet<SmpcCallType> SmpcCallTypes { get; set; }
        public virtual DbSet<SmpcCallReason> SmpcCallReasons { get; set; }
        public virtual DbSet<SmpcDepartment> SmpcDepartments { get; set; }
        public virtual DbSet<SmpcZone> SmpcZones { get; set; }
        public virtual DbSet<SmpcAccidentType> SmpcAccidentTypes { get; set; }
        public virtual DbSet<SmpcCaller> SmpcCallers { get; set; }
        public virtual DbSet<SmpcCase> SmpcCases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmpcZone>()
                .HasOne(z => z.Organigram)
                .WithMany()
                .HasForeignKey(z => z.OrgId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SmpcCase>()
                .HasOne(z => z.CallType)
                .WithMany()
                .HasForeignKey(z => z.IDSMPCCallTypes)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SmpcCase>()
               .HasOne(z => z.Caller)
               .WithMany()
               .HasForeignKey(z => z.IDSMPCCaller)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SmpcCase>()
               .HasOne(z => z.CallReason)
               .WithMany()
               .HasForeignKey(z => z.IDSMPCCallReason)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SmpcCase>()
                .HasOne(z => z.Organigram)
                .WithMany()
                .HasForeignKey(z => z.OrgId);

            modelBuilder.Entity<SmpcCase>()
                .HasOne(z => z.CoverageZone)
                .WithMany()
                .HasForeignKey(z => z.IDSMPCCoverageZone)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            if (!optionsBuilder.IsConfigured) {

                var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName; 

                var configPath = Path.Combine(projectDir, "SMPC.Server", "appsettings.json");

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(configPath)
                    .Build(); 
                var connectionString = configuration.GetConnectionString("SMPC"); 
                optionsBuilder.UseSqlServer(connectionString); 
            } 
        }

    }
}
