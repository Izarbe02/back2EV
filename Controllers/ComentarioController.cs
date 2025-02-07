using Microsoft.AspNetCore.Mvc;
using dosEvAPI.Repositories;
using dosEvAPI.Service;


//sin put
namespace dosEvAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioService _serviceComentario;

        public ComentarioController(IComentarioService service)
        {
            _serviceComentario = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comentario>>> GetComentarios()
        {
            var comentarios = await _serviceComentario.GetAllAsync();
            return Ok(comentarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> GetComentario(int id)
        {
            var comentario = await _serviceComentario.GetByIdAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
            return Ok(comentario);
        }

        [HttpPost]
        public async Task<ActionResult<Comentario>> CreateComentario(Comentario comentario)
        {
            await _serviceComentario.AddAsync(comentario);
            return CreatedAtAction(nameof(GetComentario), new { id = comentario.Id }, comentario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComentario(int id)
        {
            var comentario = await _serviceComentario.GetByIdAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
            await _serviceComentario.DeleteAsync(id);
            return NoContent();
        }
    }
}
