using Moji.Application.DTOS.Generic;
using Moji.Application.DTOS.Post;
using Moji.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Moji.Application.Interfaces
{
    public interface IPostRepository:IGenericRepository<Post>
    {
        Task<PageResult<Post>> GetPageAsync(QueryPostRequest request);
        Task<Post?> GetDetailByIdAsync(int id);
        Task<Post?> GetForUpdateAsync(int id);
    }
}
