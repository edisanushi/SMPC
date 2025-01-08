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
        public virtual DbSet<SmpcClosedCase> SmpcClosedCases { get; set; }
        public virtual DbSet<SmpcConnection> SmpcConnections { get; set; }
        public virtual DbSet<SmpcConsequence> SmpcConsequences { get; set; }
        public virtual DbSet<SmpcCooporationType> CooperationTypes { get; set; }
        public virtual DbSet<SmpcUser> SmpcUsers { get; set; }
        public virtual DbSet<SmpcCriminalOffense> SmpcCriminalOffenses { get; set; }
        public virtual DbSet<SmpcDistributedCase> SmpcDistributedCases { get; set; }
        public virtual DbSet<SmpcDrugType> SmpcDrugTypes { get; set; }
        public virtual DbSet<SmpcEthnicity> SmpcEthnicities { get; set; }
        public virtual DbSet<SmpcEventReason> SmpcEventReasons { get; set; }
        public virtual DbSet<SmpcEvidenceMethod> SmpcEvidenceMethods { get; set; }
        public virtual DbSet<SmpcEvientInvolvement> SmpcEvientInvolvements { get; set; }
        public virtual DbSet<SmpcEyeColor> SmpcEyeColors { get; set; }
        public virtual DbSet<SmpcHairColor> SmpcHairColors { get; set; }
        public virtual DbSet<SmpcLighting> SmpcLightings { get; set; }
        public virtual DbSet<SmpcMentalHealth> SmpcMentalHealths { get; set; }
        public virtual DbSet<SmpcModusOperandus> SmpcModusOperandus { get; set; }
        public virtual DbSet<SmpcNonCriminalCase> SmpcNonCriminalCases { get; set; }
        public virtual DbSet<SmpcObjectClassification> SmpcObjectClassifications { get; set; }
        public virtual DbSet<SmpcOrganizationType> SmpcOrganizationTypes { get; set; }
        public virtual DbSet<SmpcPlaceType> SmpcPlaceTypes { get; set; }
        public virtual DbSet<SmpcProsecutor> SmpcProsecutors { get; set; }
        public virtual DbSet<SmpcSpecialQuality> SmpcSpecialQualities { get; set; }
        public virtual DbSet<SmpcStreetCondition> SmpcStreetConditions { get; set; }
        public virtual DbSet<SmpcStreetSignal> SmpcStreetSignals { get; set; }
        public virtual DbSet<SmpcStreetType> SmpcStreetTypes { get; set; }
        public virtual DbSet<SmpcSurfaceType> SmpcSurfaceTypes { get; set; }
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

            modelBuilder.Entity<SmpcClosedCase>()
               .HasOne(z => z.CallType)
               .WithMany()
               .HasForeignKey(z => z.IDSMPCVerification)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SmpcClosedCase>()
               .HasOne(z => z.CallReason)
               .WithMany()
               .HasForeignKey(z => z.IDSMPCVerificatonResult)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SmpcClosedCase>()
               .HasOne(z => z.Case)
               .WithMany()
               .HasForeignKey(z => z.IDSMPCCase)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SmpcClosedCase>()
               .HasOne(z => z.User)
               .WithMany()
               .HasForeignKey(z => z.IdUnUser)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SmpcDistributedCase>()
               .HasOne(z => z.Case)
               .WithMany()
               .HasForeignKey(z => z.IDSMPCCase)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SmpcDistributedCase>()
               .HasOne(z => z.Zone)
               .WithMany()
               .HasForeignKey(z => z.IDSMPCCoverageZone)
               .OnDelete(DeleteBehavior.Cascade);

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
