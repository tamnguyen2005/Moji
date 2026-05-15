using Moji.Application.DTOS.User;
using Moji.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Moji.Application.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        Task<List<User>> GetAsync();
        Task<User?> GetByIdAsync(int id);
        Task<List<User>> FindAsync(Expression<Func<User,bool>> ex);
    }
}
