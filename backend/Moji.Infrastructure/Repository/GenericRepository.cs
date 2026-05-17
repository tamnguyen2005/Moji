using Microsoft.EntityFrameworkCore;
using Moji.Application.Interfaces;
using Moji.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Moji.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MojiDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(MojiDbContext context) {
            _context= context;
            _dbSet= _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> ex)
        {
            var queryAble= _dbSet.AsQueryable();
            queryAble= queryAble.Where(ex);
            var result= await queryAble.ToListAsync();
            return result;
        }

        public async Task<List<T>> GetAsync()
        {
            var result=await _dbSet.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
