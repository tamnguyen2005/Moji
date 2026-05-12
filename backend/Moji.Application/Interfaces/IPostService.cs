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
        Task<PostResponse> GetPostAsync(QueryPostRequest request);
        Task UpdatePostAsync(UpdatePostRequest request);
        Task DeletePostAsync(int id);
    }
}
