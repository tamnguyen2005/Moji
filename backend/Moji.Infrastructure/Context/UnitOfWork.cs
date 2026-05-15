using Moji.Application.Interfaces;
using Moji.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MojiDbContext _context;
        public UnitOfWork(MojiDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
