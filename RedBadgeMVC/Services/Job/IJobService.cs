using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedBadgeMVC.Models.Job;

namespace RedBadgeMVC.Services.Job
{
    public interface IJobService
    {
        Task<bool> CreateJobAsync(JobCreate request);
        Task<bool> RemoveJobByIdAsync(int JobId);
        Task<IEnumerable<JobDetail>> GetJobListAsync();
        Task<bool> UpdateJobByIdAsync(int jobId, JobUpdate update);
    }
}