using Moji.Application.DTOS.University;
using Moji.Application.Interfaces;
using Moji.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<University> _universityRepository;
        public UniversityService(IUnitOfWork unitOfWork, IGenericRepository<University> universityRepository)
        {
            _unitOfWork = unitOfWork;
            _universityRepository = universityRepository;
        }

        public async Task CreateUniversityAsync(CreateUniversityRequest request)
        {
            var university = new University
            {
                Name = request.Name,
                ShortName = request.ShortName,
            };
            _universityRepository.Add(university);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUniversityAsync(int id)
        {
            var university=await _universityRepository.GetByIdAsync(id);
            if (university == null)
            {
                throw new KeyNotFoundException("University does not exist !");
            }
            _universityRepository.Delete(university);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<UniversityResponse>> GetUniversityAsync()
        {
            var university=await _universityRepository.GetAsync();
            var result = university.Select(u=>new UniversityResponse
            {
                Id = u.Id,
                Name=u.Name,
            }).ToList();
            return result;
        }

        public async Task UpdateUniversityAsync(int id, UpdateUniversityRequest request)
        {
            var university = await _universityRepository.GetByIdAsync(id);
            if(university==null)
            {
                throw new KeyNotFoundException("University does not exist !");
            }
            if(!string.IsNullOrEmpty(request.Name))
            {
                university.Name = request.Name;
            }
            if(!string.IsNullOrEmpty(request.ShortName))
            {
                university.ShortName = request.ShortName;
            }    
            _universityRepository.Update(university);
            await _unitOfWork.SaveChangesAsync();

        }
    }
}
