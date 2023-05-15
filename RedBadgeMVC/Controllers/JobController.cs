using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedBadgeMVC.Models.Job;
using RedBadgeMVC.Services.Job;

namespace RedBadgeMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [Authorize(Policy = "CustomCompanyEntity")]
        [HttpPost]
        public async Task<IActionResult> CreateJob(JobCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _jobService.CreateJobAsync(model))
            {
                return Ok("Job added to database");
            }
            return BadRequest("Job could not be added to database");
        }

        [Authorize (Policy = "CustomCompanyEntity")]
        [HttpDelete("{jobId:int}")]
        public async Task<IActionResult> RemoveJobById([FromRoute] int jobId)
        {
            return await _jobService.RemoveJobByIdAsync(jobId)
                ? Ok($"Job {jobId} was deleted successfully.")
                : BadRequest($"Job {jobId} could not be deleted.");
        }
        
        [HttpGet]
        public async Task<IActionResult> GetJobListAsync()
        {
            var JobsToDisplay = await _jobService.GetJobListAsync();
            return Ok(JobsToDisplay);
        }

        [Authorize(Policy = "CustomCompanyEntity")]
        [HttpPut("{jobId:int}")]
        public async Task<IActionResult> UpdateJob([FromRoute]int jobId,[FromBody]JobUpdate update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _jobService.UpdateJobByIdAsync(jobId,update)
                ? Ok("Job was updated successfully.")
                : BadRequest("Job was unable to be updated.");
        }
    }
}