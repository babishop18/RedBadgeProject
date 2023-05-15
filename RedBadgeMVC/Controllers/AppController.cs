using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedBadgeMVC.Models.Applications;
using RedBadgeMVC.Models.Job;
using RedBadgeMVC.Services.Application;

namespace RedBadgeMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {
        private readonly IApplicationService _appService;
        public AppController(IApplicationService appService)
        {
            _appService = appService;
        }

        [Authorize(Policy = "CustomApplicantEntity")]
        [HttpPost]
        public async Task<IActionResult> CreateApp(AppCreate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _appService.CreateAppAsync(request))
            {
                return Ok("Application has been submitted");
            }
            return BadRequest("Application could not be submitted");
        }

        [Authorize(Policy = "CustomApplicantEntity")]
        [HttpGet]
        public async Task<IActionResult> GetUsersAppListAsync()
        {
            var AppsToDisplay = await _appService.GetUsersAppListAsync();
            return Ok(AppsToDisplay);
        }

        [Authorize(Policy = "CustomCompanyEntity")]
        [HttpGet]
        public async Task<IActionResult> GetJobsAppListAsync()
        {
            var AppsToDisplay = await _appService.GetJobsAppListAsync();
            return Ok(AppsToDisplay);
        }

    // ASK ABOUT ONLY ALLOWING THE APPLICANT AND COMPANY INVOLVED TO HAVE ACCESS TO FIND THIS IN SEARCH
        [HttpGet("{AppId:int}")]
        public async Task<IActionResult> GetAppByIdAsync([FromRoute] int AppId)
        {
            var AppToDisplay = await _appService.GetAppByIdAsync(AppId);
            return Ok(AppToDisplay);
        }
    }
}