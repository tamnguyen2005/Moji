using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Interfaces
{
    public interface ICurrentUser
    {
        int UserId {  get; }
        int UniversityId {  get; }
    }
}
