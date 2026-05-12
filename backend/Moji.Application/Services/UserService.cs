using Moji.Application.DTOS.User;
using Moji.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Task<LoginResponse> Login(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
