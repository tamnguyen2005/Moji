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
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        private readonly MojiDbContext _context;
        public UserRepository(MojiDbContext context):base(context)
        {
            _context = context;
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
    }
}
