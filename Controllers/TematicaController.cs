using Microsoft.AspNetCore.Mvc;
using dosEvAPI.Repositories;
using dosEvAPI.Service;
using Models;

namespace dosEvAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class TematicaController : ControllerBase
    {
        private readonly ITematicaService _serviceTematica;

        public TematicaController(ITematicaService service)
        {
            _serviceTematica = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tematica>>> GetTematicas()
        {
            var tematicas = await _serviceTematica.GetAllAsync();
            return Ok(tematicas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tematica>> GetTematica(int id)
        {
            var tematica = await _serviceTematica.GetByIdAsync(id);
            if (tematica == null)
            {
                return NotFound();
            }
            return Ok(tematica);
        }

        [HttpPost]
        public async Task<ActionResult<Tematica>> CreateTematica(Tematica tematica)
        {
            await _serviceTematica.AddAsync(tematica);
            return CreatedAtAction(nameof(GetTematica), new { id = tematica.Id }, tematica);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTematica(int id, Tematica updatedTematica)
        {
            var existingTematica = await _serviceTematica.GetByIdAsync(id);
            if (existingTematica == null)
            {
                return NotFound();
            }

            existingTematica.Nombre = updatedTematica.Nombre;

            await _serviceTematica.UpdateAsync(existingTematica);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTematica(int id)
        {
            var tematica = await _serviceTematica.GetByIdAsync(id);
            if (tematica == null)
            {
                return NotFound();
            }
            await _serviceTematica.DeleteAsync(id);
            return NoContent();
        }
    }
}
