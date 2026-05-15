using Moji.Application.DTOS.User;
using Moji.Application.Interfaces;
using Moji.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;
        private readonly IGenerateToken _generateToken;
        private readonly IHashPassword _hashPassword;

        public UserService(IUnitOfWork uow, IUserRepository userRepository, IGenerateToken generateToken, IHashPassword hashPassword)
        {
            _uow = uow;
            _userRepository = userRepository;
            _generateToken = generateToken;
            _hashPassword = hashPassword;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var users = await _userRepository.FindAsync(u=>u.Email==request.UserName);
            var user=users.FirstOrDefault();
            if (user == null)
                throw new KeyNotFoundException("Username or Password is not correct !");
            var hashPassword = _hashPassword.Compare(user.PasswordHash,request.Password);
            if (!hashPassword)
                throw new UnauthorizedAccessException("Username or Password is not correct !");
            var accessToken = _generateToken.CreateAccessToken(user.Id,user.UniversityId);
            var refreshToken = _generateToken.CreateRefreshToken();
            var rt = new RefreshToken
            {
                Token=refreshToken,
                ExpiresAt=DateTime.Now.AddDays(7),
                IsRevoked=false,
                UserId=user.Id,
            };
            user.RefreshTokens.Add(rt);
            await _uow.SaveChangesAsync();
            return new LoginResponse 
            { 
                AccessToken=accessToken,
                RefreshToken=refreshToken
            };
            

        }

        public async Task Register(RegisterRequest request)
        {
            var users = await _userRepository.FindAsync(u=>u.Email==request.Email);
            if (users.Any())
                throw new InvalidOperationException("Email has already been used !");
            var passwordHash = _hashPassword.Hash(request.Password);
            var user = new User
            {
                Name=request.Name,
                Email=request.Email,
                CreateAt=DateTime.Now,
                PasswordHash=passwordHash,
                UniversityId=request.UniversityId
            };
            _userRepository.Add(user);
            await _uow.SaveChangesAsync();
        }
    }
}
