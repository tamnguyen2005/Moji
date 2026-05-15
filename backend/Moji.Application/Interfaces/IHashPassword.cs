using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Interfaces
{
    public interface IHashPassword
    {
        string Hash(string password);
        bool Compare(string hashedPassword, string password);
    }
}
