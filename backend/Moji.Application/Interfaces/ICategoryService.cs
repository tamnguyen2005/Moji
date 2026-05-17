using Moji.Application.DTOS.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Interfaces
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(CreateCategoryRequest request);
        Task UpdateCategoryAsync(int id,UpdateCategoryRequest request);
        Task DeleteCategoryAsync(int id);
        Task<List<CategoryResponse>> GetCategoryAsync();
    }
}
