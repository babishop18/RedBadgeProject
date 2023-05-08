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
        public DbSet<ApplicationEntity> Applications { get; set; }
        public DbSet<JobEntity> Jobs { get; set; }
        public DbSet<ResponseEntity> Responses { get; set; }
        public DbSet<UserEntity> Users { get; set; }
         public DbSet<CompanyEntity> Companies { get; set; }
          public DbSet<ApplicantEntity> Applicants { get; set; }

    }
}