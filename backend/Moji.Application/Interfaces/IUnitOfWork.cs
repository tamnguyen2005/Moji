using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IPostRepository Post {  get; }
        IUserRepository User { get; }
        Task SaveChangesAsync();
    }
}
