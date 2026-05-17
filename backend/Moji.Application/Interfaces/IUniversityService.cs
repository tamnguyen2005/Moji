using Moji.Application.DTOS.University;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Interfaces
{
    public interface IUniversityService
    {
        Task CreateUniversityAsync(CreateUniversityRequest request);
        Task UpdateUniversityAsync(int id,UpdateUniversityRequest request);
        Task DeleteUniversityAsync(int id);
        Task<List<UniversityResponse>> GetUniversityAsync();
    }
}
