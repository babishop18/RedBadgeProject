using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedBadgeMVC.Data.Entities;
using RedBadgeMVC.Models.Token;
using RedBadgeMVC.Models.User;
using RedBadgeMVC.Services.Token;
using RedBadgeMVC.Services.User;

namespace RedBadgeMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreate newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            bool createUser = await _userService.CreateUserAsync(newUser);
            if (createUser)
            {
                return Ok("User was created.");
            }
            return BadRequest("User could not be created.");

        }

        [HttpPost("~/api/TokenCompany")]
        public async Task<IActionResult> TokenCompany([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TokenResponse tokenResponse = await _tokenService.GetTokenAsync<CompanyEntity>(request);
            if (tokenResponse is null)
            {
                return BadRequest("invalid username or password");
            }
            return Ok(tokenResponse);
        }
        
        [HttpPost("~/api/TokenApplicant")]
        public async Task<IActionResult> TokenApplicant([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TokenResponse tokenResponse = await _tokenService.GetTokenAsync<ApplicantEntity>(request);
            if (tokenResponse is null)
            {
                return BadRequest("invalid username or password");
            }
            return Ok(tokenResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {

            IEnumerable<UserList> users = await _userService.GetUserListAsync();
            return Ok(users);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserById([FromBody] UserCreate update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _userService.UpdateUserAsync(update)
                ? Ok("User was updated successfully.")
                : BadRequest("User was unable to be updated.");
        }
    }
}