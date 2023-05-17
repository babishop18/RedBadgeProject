using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RBProject.Data.Entities;

namespace RBProject.Data
{
    public class RBProjectDbContext : DbContext
    {
        public RBProjectDbContext(DbContextOptions<RBProjectDbContext> options) : base(options) { }
        public DbSet<ApplicationEntity> JobApps { get; set; }
        public DbSet<JobEntity> Jobs { get; set; }
        public DbSet<ApplicationEntity> Applications { get; set; }
        public DbSet<ResponseEntity> Responses { get; set; }
        public DbSet<UserEntity> Users { get; set; }
         public DbSet<CompanyEntity> Companies { get; set; }
          public DbSet<ApplicantEntity> Applicants { get; set; }
    }
}