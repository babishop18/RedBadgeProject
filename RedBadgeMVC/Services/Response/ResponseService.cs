using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using RedBadgeMVC.Data;
using RedBadgeMVC.Data.Entities;
using RedBadgeMVC.Models.Response;

namespace RedBadgeMVC.Services.Response
{
    public class ResponseService : IResponseService
    {
        private readonly int _companyFKey;
        private readonly int _appFKey;
        private readonly RedBadgeProjectDbContext _context;

        public ResponseService(IHttpContextAccessor httpContextAccessor, RedBadgeProjectDbContext dbContext)
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

        public async Task<bool> CreateResponseAsync(ResponseCreate request)
        {
            ResponseEntity newResponse = new ResponseEntity
            {
//                ResponseStatus = request.ResponseStatus,
                ResponseMessage = request.ResponseMessage,
                DateResponded = DateTime.Now
            };
            _context.Responses.Add(newResponse);
            int numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }
    }
}