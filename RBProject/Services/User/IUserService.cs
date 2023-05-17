using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RBProject.Models.User;

namespace RBProject.Services.User
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserCreate newUser);
        Task<bool> UpdateUserAsync(UserCreate update);
        Task<bool> RemoveCompanyAsync(int userId);
        Task<bool> RemoveApplicantAsync(int userId);
        Task<IEnumerable<UserList>> GetUserListAsync();
    }
}