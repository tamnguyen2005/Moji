using Microsoft.EntityFrameworkCore;
using Moji.Application.Interfaces;
using Moji.Domain.Entities;
using Moji.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Moji.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MojiDbContext _context;
        public UserRepository(MojiDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<List<User>> FindAsync(Expression<Func<User,bool>> ex)
        {
            var queryAble=_context.Users.AsQueryable();
            queryAble = queryAble.Where(ex);
            var result=await queryAble.ToListAsync();
            return result;
        }

        public async Task<List<User>> GetAsync()
        {
            var result = await _context.Users.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var result=await _context.Users.FindAsync(id);
            return result;
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
