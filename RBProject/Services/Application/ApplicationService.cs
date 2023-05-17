using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RBProject.Data;
using RBProject.Data.Entities;
using RBProject.Models.Application;

namespace RBProject.Services.Application
{
    public class ApplicationService : IApplicationService
    {
        private readonly int _applicantFKey;
        private readonly RedBadgeProjectDbContext _context;

        public ApplicationService(IHttpContextAccessor httpContextAccessor, RedBadgeProjectDbContext dbContext)
        {
            ClaimsIdentity? userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            string value = userClaims.FindFirst("Id")?.Value;
            bool validId = int.TryParse(value, out _applicantFKey);
            if (!validId)
            {
                throw new Exception("Attempted to build without applicant Id Claim");
            }
            _context = dbContext;
        }

        public async Task<bool> CreateAppAsync(AppCreate request)
        {
            ApplicationEntity newApp = new ApplicationEntity
            {
                JobId = request.JobId,
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                FullAddress = request.FullAddress,
                Education = request.Education,
                Experience = request.Experience,
                DesiredPay = request.DesiredPay,
                HasResponse = false,
                DateSubmitted = DateTime.Now
            };
            _context.JobApps.Add(newApp);
            int numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

// ASK HOW TO REFERENCE JOB TITLE THAT THIS APPLICATION IS CONNECTED WITH
        public async Task<IEnumerable<UserAppListItem>> GetUsersAppListAsync()
        {
            var AppToDisplay = await _context.JobApps.Where(entity => entity.ApplicantFKey == _applicantFKey)
                .Select(entity => new UserAppListItem
                {
                    JobTitle = entity.Job.JobTitle
                }).ToListAsync();

            return AppToDisplay;
        }

        public async Task<IEnumerable<AppListItem>> GetJobsAppListAsync(int jobId)
        {
            var AppToDisplay = await _context.JobApps.Where(entity => entity.JobId == jobId)
                .Select(entity => new AppListItem
                {
                    FullName = entity.FullName,
                    DateSubmitted = entity.DateSubmitted,
                    HasResponse = entity.HasResponse,
                    PhoneNumber = entity.PhoneNumber,
                    AppId = entity.AppId

                }).ToListAsync();

            return AppToDisplay;
        }

        public async Task<AppDetail> GetAppByIdAsync(int AppId)
        {
            ApplicationEntity entity = await _context.JobApps.FindAsync(AppId);
            if (entity is null)
                return null;

            var AppDetail = new AppDetail
            {
                AppId = entity.AppId,
                FullName = entity.FullName,
                PhoneNumber = entity.PhoneNumber,
                FullAddress = entity.FullAddress,
                Education = entity.Education,
                Experience = entity.Experience,
                DesiredPay = entity.DesiredPay,
                HasResponse = false,
                DateSubmitted = DateTime.Now
            };
            return AppDetail;
        }
    }
}