using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RBProject.Data.Entities;
using RBProject.Models.Token;

namespace RBProject.Services.Token
{
    public interface ITokenService
    {
        Task<TokenResponse> GetTokenAsync<T>(TokenRequest model) where T: UserEntity;
    }
}