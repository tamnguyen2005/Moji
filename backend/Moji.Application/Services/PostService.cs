using Moji.Application.DTOS.Generic;
using Moji.Application.DTOS.Post;
using Moji.Application.Interfaces;
using Moji.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Services
{
    public class PostService : IPostService
    {
        private IUnitOfWork _uow;
        private IPostRepository _postRepository;
        private IPhotoService _photoService;
        private ICurrentUser _currentUser;
        public PostService(IUnitOfWork uow, IPostRepository postRepository, IPhotoService photoService, ICurrentUser currentUser)
        {
            _uow = uow;
            _postRepository = postRepository;
            _photoService = photoService;
            _currentUser = currentUser;
        }
        public async Task CreatePostAsync(CreatePostRequest request)
        {
            var post = new Post
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId,
                Status="Avaible",
                CreateAt = DateTime.Now,
                CreatorId=_currentUser.UserId,
                UniversityId=_currentUser.UniversityId
            };
            foreach(var i in request.Images)
            {
                var url = await _photoService.Upload(i);
                var image = new Image
                {
                    Url = url,
                };
                post.Images.Add(image);
            }
            _postRepository.Add(post);
            await _uow.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var post=await _postRepository.GetByIdAsync(id);
            if(post==null)
            {
                throw new KeyNotFoundException("Post does not exist !");
            }    
            _postRepository.Delete(post);
            await _uow.SaveChangesAsync();
        }

        public async Task<PageResult<PostResponse>> GetPostAsync(QueryPostRequest request)
        {
            var result = await _postRepository.GetAsync(request);
            return new PageResult<PostResponse>
            {
                Items = result.Items.Select(i => new PostResponse
                {
                    Id = i.Id,
                    Location = i.University.Name,
                    Title = i.Title,
                    Price = i.Price,
                    Status = i.Status
                }).ToList(),
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                TotalCount = result.TotalCount,
            };
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
