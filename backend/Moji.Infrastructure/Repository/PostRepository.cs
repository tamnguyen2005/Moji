using Microsoft.EntityFrameworkCore;
using Moji.Application.DTOS.Post;
using Moji.Application.Interfaces;
using Moji.Domain.Entities;
using Moji.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Moji.Infrastructure.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly MojiDbContext _context;
        public PostRepository(MojiDbContext context)
        {
            _context = context;
        }

        public void Add(Post post)
        {
            _context.Posts.Add(post);
        }

        public void Delete(Post post)
        {
            _context.Remove(post);
        }

        public async Task<List<Post>> FindAsync(Expression<Func< Post,bool>> ex)
        {
            var queryAble=_context.Posts.AsQueryable();
            queryAble = queryAble.Where(ex);
            queryAble = queryAble.AsNoTracking();
            var result= await queryAble.ToListAsync();
            return result;
        }

        public async Task<List<Post>> GetAsync(QueryPostRequest request)
        {
            var queryAble= _context.Posts.AsQueryable();
            if(!string.IsNullOrEmpty(request.Title))
            {
                queryAble = queryAble.Where(p => p.Title.Contains(request.Title));
            }
            if(request.MinPrice.HasValue)
            {
                queryAble = queryAble.Where(p=>p.Price>=request.MinPrice);
            }
            if(request.MaxPrice.HasValue)
            {
                queryAble = queryAble.Where(p=>p.Price<=request.MaxPrice);
            }
            if(request.UniversityId.HasValue)
            {
                queryAble = queryAble.Where(p=>p.UniversityId==request.UniversityId);
            }
            queryAble=queryAble.AsNoTracking();
            var result = await queryAble.OrderByDescending(p => p.CreateAt)
                                        .Skip((request.PageNumber-1)*request.PageSize)
                                        .Take(request.PageSize)
                                        .ToListAsync();
            return result;
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            var result=await _context.Posts.FindAsync(id);
            return result;
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
        }
    }
}
