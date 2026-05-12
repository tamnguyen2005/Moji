using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.DTOS.User
{
    public class LoginResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string? RefreshToken {  get; set; } = string.Empty;
    }
}
