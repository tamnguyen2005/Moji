using Moji.Application.DTOS.Category;
using Moji.Application.Interfaces;
using Moji.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _uow;
        private readonly IPhotoService _photoService;
        public CategoryService(IGenericRepository<Category> categoryRepository, IUnitOfWork uow, IPhotoService photoService)
        {
            _categoryRepository = categoryRepository;
            _uow = uow;
            _photoService = photoService;
        }

        public async Task CreateCategoryAsync(CreateCategoryRequest request)
        {
            var category = new Category
            {
                Name= request.Name,
            };
            if(request.Image!=null && request.Image.Length>0)
            {
                var url = await _photoService.Upload(request.Image);
                category.Image = url;
            }    
            _categoryRepository.Add(category);
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category=await _categoryRepository.GetByIdAsync(id);
            if(category==null)
                throw new KeyNotFoundException("Category does not exist !");
            _categoryRepository.Delete(category);
            await _uow.SaveChangesAsync();
        }

        public async Task<List<CategoryResponse>> GetCategoryAsync()
        {
            var category = await _categoryRepository.GetAsync();
            var result=category.Select(c=>new CategoryResponse
            {
                Id=c.Id,
                Name=c.Name,
                Image=c.Image,
            }).ToList();
            return result;
        }

        public async Task UpdateCategoryAsync(int id, UpdateCategoryRequest request)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new KeyNotFoundException("Category does not exist !");
            if(string.IsNullOrEmpty(request.Name))
                category.Name= request.Name;
            _categoryRepository.Update(category);
            await _uow.SaveChangesAsync();
        }
    }
}
