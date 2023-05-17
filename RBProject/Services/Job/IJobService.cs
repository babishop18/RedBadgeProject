using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RBProject.Models.Job;

namespace RBProject.Services.Job
{
    public interface IJobService
    {
        Task<bool> CreateJobAsync(JobCreate request);
        Task<bool> RemoveJobByIdAsync(int JobId);
        Task<List<JobListItem>> GetJobListAsync();
        Task<bool> UpdateJobByIdAsync(int jobId, JobUpdate update);
        Task<List<JobListItem>> GetAllJobsAsync();
        Task<JobListItem> GetJobById(int id);
    }
}