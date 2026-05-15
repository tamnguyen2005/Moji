using BCrypt.Net;
using Moji.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Infrastructure.Auth
{
    public class HashPassword : IHashPassword
    {
        public bool Compare(string hashedPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password,hashedPassword);
        }

        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
