using Microsoft.AspNetCore.Mvc;
using Moji.Application.DTOS.University;
using Moji.Application.Interfaces;

namespace Moji.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityService _universityService;
        public UniversityController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUniversity() 
        { 
            var result=await _universityService.GetUniversityAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUniversity(CreateUniversityRequest request)
        {
            await _universityService.CreateUniversityAsync(request);
            return Created();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUniversity(int id,UpdateUniversityRequest request)
        {
            await _universityService.UpdateUniversityAsync(id,request);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUniversity(int id)
        {
            await _universityService.DeleteUniversityAsync(id);
            return NoContent();
        }
    }
}
