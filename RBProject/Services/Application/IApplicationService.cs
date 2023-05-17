using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RBProject.Models.Application;

namespace RBProject.Services.Application
{
    public interface IApplicationService
    {
        Task<bool> CreateAppAsync(AppCreate request);
        Task<IEnumerable<UserAppListItem>> GetUsersAppListAsync();
        Task<IEnumerable<AppListItem>> GetJobsAppListAsync(int jobId);
        Task<AppDetail> GetAppByIdAsync(int AppId);
    }
}