using Microsoft.AspNetCore.Mvc;
using dosEvAPI.Repositories;
using dosEvAPI.Service;

namespace dosEvAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _servicePost;

        public PostController(IPostService service)
        {
            _servicePost = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            var posts = await _servicePost.GetAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _servicePost.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            await _servicePost.AddAsync(post);
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, Post updatedPost)
        {
            var existingPost = await _servicePost.GetByIdAsync(id);
            if (existingPost == null)
            {
                return NotFound();
            }

            existingPost.Titulo = updatedPost.Titulo;
            existingPost.Contenido = updatedPost.Contenido;
            existingPost.Fecha = updatedPost.Fecha;

            await _servicePost.UpdateAsync(existingPost);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _servicePost.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            await _servicePost.DeleteAsync(id);
            return NoContent();
        }
    }
}
