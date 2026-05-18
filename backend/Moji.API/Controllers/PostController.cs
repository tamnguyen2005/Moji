using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moji.Application.DTOS.Post;
using Moji.Application.Interfaces;

namespace Moji.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery]QueryPostRequest request)
        {
            var result=await _postService.GetPostAsync(request);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById([FromRoute]int id)
        {
            var result=await _postService.GetPostByIdAsync(id);
            return Ok(result);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost([FromForm]CreatePostRequest request)
        {
            await _postService.CreatePostAsync(request);
            return Created();
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePost([FromRoute]int id,[FromBody]UpdatePostRequest request)
        {
            await _postService.UpdatePostAsync(id,request);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            await (_postService.DeletePostAsync(id));
            return NoContent();
        }

    }
}
