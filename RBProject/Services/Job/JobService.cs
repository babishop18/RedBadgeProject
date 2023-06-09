using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RBProject.Data;
using RBProject.Data.Entities;


namespace RBProject.Services.Job
{
    public class JobService : IJobService
    {
        private readonly int _companyFKey;
        private readonly RBProjectDbContext _context;

        public JobService(IHttpContextAccessor httpContextAccessor, RBProjectDbContext dbContext)
        {
            ClaimsIdentity? userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            string value = userClaims.FindFirst("Id")?.Value;
            bool validId = int.TryParse(value, out _companyFKey);
            if (!validId)
            {
                throw new Exception("Attempted to build without company Id Claim");
            }
            _context = dbContext;
        }

        public async Task<bool> CreateJobAsync (JobCreate request)
        {
            JobEntity newJob = new JobEntity
            {
                JobTitle = request.JobTitle,
                JobSalary = request.JobSalary,
                JobHourlyPay = request.JobHourlyPay,
                JobLocation = request.JobLocation,
                JobRequirements = request.JobRequirements,
                JobSummary = request.JobSummary,
                JobDescription = request.JobDescription,
                JobIsAvailable = request.JobIsAvailable,
                CompanyFKey = _companyFKey

            };
            _context.Jobs.Add(newJob);
            int numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> RemoveJobByIdAsync(int JobId)
        {
            var jobToRemove = await _context.Jobs.Where(entity => entity.CompanyFKey == _companyFKey).FirstOrDefaultAsync(s => s.JobId == JobId);

            if (jobToRemove == null)
            {
                return false;
            }
            if (jobToRemove.JobApps.Count != 0)
            {
                return false;
            }
            _context.Jobs.Remove(jobToRemove);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<List<JobListItem>> GetJobListAsync()
        {
            var JobsToDisplay = await _context.Jobs.Where(entity => entity.CompanyFKey == _companyFKey)
                .Select(entity => new JobListItem
                {
                    JobTitle = entity.JobTitle,
                    JobId = entity.JobId,
                    JobSalary = entity.JobSalary,
                    JobHourlyPay = entity.JobHourlyPay,
                    JobLocation = entity.JobLocation,
                    JobSummary = entity.JobSummary
                }).ToListAsync();
            
            return JobsToDisplay;
        }

        public async Task<List<JobListItem>> GetAllJobsAsync()
        {
            var JobsToDisplay = await _context.Jobs
                .Select(entity => new JobListItem
                {
                    JobTitle = entity.JobTitle,
                    JobId = entity.JobId,
                    JobSalary = entity.JobSalary,
                    JobHourlyPay = entity.JobHourlyPay,
                    JobLocation = entity.JobLocation,
                    JobSummary = entity.JobSummary
                }).ToListAsync();

            return JobsToDisplay;
        }

        public async Task<JobListItem> GetJobById(int id)
        {
            JobEntity? job = await _context.Jobs
                .Include(r => r.JobApps)
                .FirstOrDefaultAsync(r => r.JobId == id);
            if (job is null) {
                return null;
            }
            JobListItem jobDetail = new JobListItem()
            {
                
            };
            return jobDetail;
        }

        public async Task<bool> UpdateJobByIdAsync(int jobId,JobUpdate update)
        {
            var jobEntity = await _context.Jobs.FirstOrDefaultAsync(c => c.JobId == jobId);
            if (jobEntity == null)
                return false;

            jobEntity.JobTitle = update.JobTitle;
            jobEntity.JobSalary = update.JobSalary;
            jobEntity.JobHourlyPay = update.JobHourlyPay;
            jobEntity.JobLocation = update.JobLocation;
            jobEntity.JobRequirements = update.JobRequirements;
            jobEntity.JobSummary = update.JobSummary;
            jobEntity.JobDescription = update.JobDescription;
            jobEntity.JobIsAvailable = update.JobIsAvailable;


            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
            
        }
    }
}