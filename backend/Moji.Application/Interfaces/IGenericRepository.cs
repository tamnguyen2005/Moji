using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Moji.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> ex);
        Task<List<T>> GetAsync();
        Task<T?> GetByIdAsync(int id);
    }
}
