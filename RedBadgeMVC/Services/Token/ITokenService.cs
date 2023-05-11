using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedBadgeMVC.Data.Entities;
using RedBadgeMVC.Models.Token;

namespace RedBadgeMVC.Services.Token
{
    public interface ITokenService
    {
        Task<TokenResponse> GetTokenAsync<T>(TokenRequest model) where T: UserEntity;
    }
}