using Moji.Application.DTOS.User;
using Moji.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Moji.Application.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<List<User>> GetAsync();
        Task<User?> GetByIdAsync(int id);
    }
}
