using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RedBadgeMVC.Data;
using RedBadgeMVC.Data.Entities;
using RedBadgeMVC.Models.User;

namespace RedBadgeMVC.Services.User
{
    public class UserService : IUserService
    {
        private readonly RedBadgeProjectDbContext _context;
        public UserService(RedBadgeProjectDbContext context, IConfiguration configuration)
        {
            _context = context;
        }

        public async Task<bool> CreateUserAsync(UserCreate newUser)
        {
            if (newUser.Role.ToLower() == "company")
            {
                CompanyEntity entity = new CompanyEntity
                {
                    Username = newUser.UserName
                };
                PasswordHasher<CompanyEntity> passwordHasher = new PasswordHasher<CompanyEntity>();
                entity.Password = passwordHasher.HashPassword(entity, newUser.Password);
                _context.Users.Add(entity);
                int numberOfChanges = await _context.SaveChangesAsync();
                return numberOfChanges == 1;
            }

            if (newUser.Role.ToLower() == "applicant")
            {
                ApplicantEntity entity = new ApplicantEntity
                {
                    Username = newUser.UserName
                };
                PasswordHasher<ApplicantEntity> passwordHasher = new PasswordHasher<ApplicantEntity>();
                entity.Password = passwordHasher.HashPassword(entity, newUser.Password);
                _context.Users.Add(entity);
                int numberOfChanges = await _context.SaveChangesAsync();
                return numberOfChanges == 1;
            }
            int counter = await _context.SaveChangesAsync();
            return counter == 1;
        }
        public async Task<bool> RemoveCompanyAsync(int userId)
        {
            var userEntity = await _context.Users.OfType<CompanyEntity>().FirstOrDefaultAsync(g => g.Id == userId);
            if (userEntity == null)

                return false;

            _context.Users.Remove(userEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> RemoveApplicantAsync(int userId)
        {
            var userEntity = await _context.Users.OfType<ApplicantEntity>().FirstOrDefaultAsync(g => g.Id == userId);
            if (userEntity == null)

                return false;

            _context.Users.Remove(userEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<UserList>> GetUserListAsync()
        {

            IEnumerable<UserList> users = await _context.Users.Select(entity => new UserList
            {
                Role = entity.GetType().Name,
                Id = entity.Id,
                UserName = entity.Username
            }).ToListAsync();
            return users;
        }

        public async Task<bool> UpdateUserAsync(UserCreate update)
        {
            if (update.Role.ToLower() == "company")
            {
                var userEntity = await _context.Users.FindAsync(update);
                if (userEntity.Id != null)
                    return false;

                userEntity.Username = update.UserName;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
            }
            if (update.Role.ToLower() == "applicant")
            {
                var userEntity = await _context.Users.FindAsync(update);
                if (userEntity.Id != null)
                    return false;

                userEntity.Username = update.UserName;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
            }
            int counter = await _context.SaveChangesAsync();
            return counter == 1;
        }
    }
}