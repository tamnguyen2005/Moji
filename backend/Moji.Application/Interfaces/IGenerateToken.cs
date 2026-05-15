using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Interfaces
{
    public interface IGenerateToken
    {
        string CreateAccessToken(int userId,int universityId);
        string CreateRefreshToken();
    }
}
