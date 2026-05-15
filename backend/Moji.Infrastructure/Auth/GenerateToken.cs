using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Moji.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Moji.Infrastructure.Auth
{
    public class GenerateToken : IGenerateToken
    {
        private readonly IConfiguration _configuration;
        public GenerateToken(IConfiguration configuration)
        {
            _configuration= configuration;
        }
        public string CreateAccessToken(int userId, int universityId)
        {
            var claims=new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier,userId.ToString()));
            claims.Add(new Claim("UniversityId",universityId.ToString()));
            var key = new SymmetricSecurityKey(System.Text.UTF8Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                            _configuration["Jwt:Audience"],
                                            claims,
                                            null, 
                                            DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:Expiry"])),
                                            creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string CreateRefreshToken()
        {
            var random = RandomNumberGenerator.GetBytes(64);
            return Convert.ToBase64String(random);
        }
    }
}
