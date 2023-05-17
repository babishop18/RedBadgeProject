using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedBadgeMVC.Data.Entities;

namespace RedBadgeMVC.Data
{
    public class RedBadgeProjectDbContext : DbContext
    {
        public RedBadgeProjectDbContext(DbContextOptions<RedBadgeProjectDbContext> options) : base(options) { }
        public DbSet<ApplicationEntity> JobApps { get; set; }
        public DbSet<JobEntity> Jobs { get; set; }
        public DbSet<ApplicationEntity> Applications { get; set; }
        public DbSet<ResponseEntity> Responses { get; set; }
        public DbSet<UserEntity> Users { get; set; }
         public DbSet<CompanyEntity> Companies { get; set; }
          public DbSet<ApplicantEntity> Applicants { get; set; }

          /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>()
                .HasDiscriminator<string>("UserType")
                .HasValue<CompanyEntity>("CompanyEntity")
                .HasValue<ApplicantEntity>("ApplicantEntity");

            modelBuilder.Entity<ApplicationEntity>()
                .HasOne(so => so.Applicant)
                .WithMany(c => c.UserApps)
                .HasForeignKey(so => so.ApplicantFKey)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationEntity>()
                .HasOne(so => so.Job)
                .WithMany(r => r.JobApps)
                .HasForeignKey(so => so.JobFKey)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ResponseEntity>()
                .HasOne(so => so.AppForResponse)
                .WithOne(r => r.Response)
                .HasForeignKey(so => so.AppFKey)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobEntity>()
                .HasOne(l => l.Company)
                .WithMany(r => r.Jobs) //
                .HasForeignKey(l => l.CompanyFKey)
                .OnDelete(DeleteBehavior.Restrict);

        }
*/
    }
}