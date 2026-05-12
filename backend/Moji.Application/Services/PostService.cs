using Moji.Application.DTOS.Post;
using Moji.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Services
{
    public class PostService : IPostService
    {
        private IUnitOfWork _uow;
        public PostService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public Task CreatePostAsync(CreatePostRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeletePostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse> GetPostAsync(QueryPostRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DetailPostResponse> GetPostByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePostAsync(UpdatePostRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
