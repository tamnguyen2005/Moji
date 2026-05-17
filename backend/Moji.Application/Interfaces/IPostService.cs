using Moji.Application.DTOS.Generic;
using Moji.Application.DTOS.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Interfaces
{
    public interface IPostService
    {
        Task CreatePostAsync(CreatePostRequest request);
        Task<DetailPostResponse> GetPostByIdAsync(int id);
        Task<PageResult<PostResponse>> GetPostAsync(QueryPostRequest request);
        Task UpdatePostAsync(int id,UpdatePostRequest request);
        Task DeletePostAsync(int id);
    }
}
