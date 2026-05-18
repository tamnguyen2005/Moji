using Microsoft.EntityFrameworkCore;
using Moji.Application.DTOS.Generic;
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
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly MojiDbContext _context;
        public PostRepository(MojiDbContext context):base(context)
        {
            _context = context;
        }
        public async Task<PageResult<Post>> GetPageAsync(QueryPostRequest request)
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
            if(request.CategoryId.HasValue)
            {
                queryAble = queryAble.Where(p=>p.CategoryId==request.CategoryId);
            }
            queryAble = queryAble.Include(p => p.University);
            queryAble = queryAble.Include(p => p.Images);
            queryAble = queryAble.Include(p => p.Category);
            queryAble=queryAble.AsNoTracking();
            var totalItem = await queryAble.CountAsync();
            var result = await queryAble.OrderByDescending(p => p.CreateAt)
                                        .Skip(((request.PageNumber-1)*request.PageSize)??0)
                                        .Take((request.PageSize)??10)
                                        .ToListAsync();
            return new PageResult<Post>
            {
                Items= result,
                PageNumber= (request.PageNumber)??1,
                PageSize= (request.PageSize)??10,
                TotalCount= totalItem
            };
        }

        public async Task<Post?> GetDetailByIdAsync(int id)
        {
           var result=await _context.Posts.Include(p=>p.University)
                                          .Include(p=>p.Creator)
                                          .Include(p=>p.Images)
                                          .AsNoTracking()
                                          .FirstOrDefaultAsync(p=>p.Id==id);
            return result;
        }

        public async Task<Post?> GetForUpdateAsync(int id)
        {
            var result=await _context.Posts.FirstOrDefaultAsync(p=>p.Id==id);
            return result;
        }
    }
}
