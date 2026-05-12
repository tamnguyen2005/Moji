using Moji.Application.DTOS.Post;
using Moji.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Moji.Application.Interfaces
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(Post post);
        Task<List<Post>> GetAsync(QueryPostRequest request);
        Task<Post?> GetByIdAsync(int id);
        Task<List<Post>> FindAsync(Expression<Func<Post,bool>>ex);
    }
}
