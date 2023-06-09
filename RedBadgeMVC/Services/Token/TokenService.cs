using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedBadgeMVC.Data;
using RedBadgeMVC.Data.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RedBadgeMVC.Models.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

namespace RedBadgeMVC.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly RedBadgeProjectDbContext _context;
        private readonly IConfiguration _configuration;

        public TokenService(RedBadgeProjectDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public async Task<TokenResponse> GetTokenAsync<T>(TokenRequest model) where T : UserEntity
        {
            T userEntity = await GetValidUserAsync<T>(model);
            if (userEntity is null)
            {

                return null;
            }



            return GenerateToken(userEntity);
        }
        private async Task<T> GetValidUserAsync<T>(TokenRequest model) where T : UserEntity
        {


            T? userEntity = await _context.Users.OfType<T>().FirstOrDefaultAsync(user => user.Username.ToLower() == model.Username.ToLower());
            if (userEntity is null)
                return null;
            PasswordHasher<T> passwordHasher = new PasswordHasher<T>();
            PasswordVerificationResult verifyPasswordResult = passwordHasher.VerifyHashedPassword(userEntity, userEntity.Password, model.Password);
            if (verifyPasswordResult == PasswordVerificationResult.Failed)
                return null;

            return userEntity;
        }

        private TokenResponse GenerateToken<T>(T entity) where T : UserEntity
        {
            Claim[] claims = GetClaims(entity);

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(14),
                SigningCredentials = credentials
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            TokenResponse tokenResponse = new TokenResponse
            {
                Token = tokenHandler.WriteToken(token),
                IssuedAt = token.ValidFrom,
                Expires = token.ValidTo
            };

            return tokenResponse;
        }
        private Claim[] GetClaims<T>(T user) where T: UserEntity
        {


            string userType = user.GetType().Name;

            Claim[] claims = new Claim[] { new Claim("Id", user.Id.ToString()), new Claim("Username", user.Username), new Claim("Role", userType) };

            return claims;
        }
    }
}