using Moji.Application.DTOS.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Interfaces
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task Register(RegisterRequest request);
    }
}
