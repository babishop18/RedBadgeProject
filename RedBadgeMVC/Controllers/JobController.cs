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
    [Route("[controller]")]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> JobIndex()
        {   
            List<JobListItem> jobs = await _jobService.GetAllJobsAsync();
            return View(jobs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(JobCreate request) {
            if (!ModelState.IsValid) {
                return View(request);
            }
            await _jobService.CreateJobAsync(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetJobById(int id) {
            JobListItem job = await _jobService.GetJobById(id);
            if (job is null) {
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // public async Task<IActionResult> CreateJob()
        // {
        //     return View();
        // }
        
        // [Authorize(Policy = "CustomCompanyEntity")]
        // [HttpPost]
        // public async Task<IActionResult> CreateJob(JobCreate model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View(ModelState);
        //     }
        //     if (await _jobService.CreateJobAsync(model))
        //     {
        //         return RedirectToAction("Index");
        //     }
        //     return View(ModelState);
        // }

        // [Authorize (Policy = "CustomCompanyEntity")]
        // [HttpDelete("{jobId:int}")]
        // public async Task<IActionResult> RemoveJobById([FromRoute] int jobId)
        // {
        //     return await _jobService.RemoveJobByIdAsync(jobId)
        //         ? Ok($"Job {jobId} was deleted successfully.")
        //         : BadRequest($"Job {jobId} could not be deleted.");
        // }
        
        // [HttpGet]
        // public async Task<IActionResult> Index()
        // {
        //     var JobsToDisplay = await _jobService.GetJobListAsync();
        //     return Ok(JobsToDisplay);
        // }

        // [Authorize(Policy = "CustomCompanyEntity")]
        // [HttpPut("{jobId:int}")]
        // public async Task<IActionResult> UpdateJob([FromRoute]int jobId,[FromBody]JobUpdate update)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);

        //     return await _jobService.UpdateJobByIdAsync(jobId,update)
        //         ? Ok("Job was updated successfully.")
        //         : BadRequest("Job was unable to be updated.");
        // }
    }
}