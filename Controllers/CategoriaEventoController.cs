using Microsoft.AspNetCore.Mvc;
using dosEvAPI.Repositories;
using dosEvAPI.Service;
using Models;

namespace dosEvAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaEventoController : ControllerBase
    {
        private readonly ICategoriaEventoService _serviceCategoriaEvento;

        public CategoriaEventoController(ICategoriaEventoService service)
        {
            _serviceCategoriaEvento = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaEvento>>> GetCategorias()
        {
            var categorias = await _serviceCategoriaEvento.GetAllAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaEvento>> GetCategoria(int id)
        {
            var categoria = await _serviceCategoriaEvento.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaEvento>> CreateCategoria(CategoriaEvento categoria)
        {
            await _serviceCategoriaEvento.AddAsync(categoria);
            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, CategoriaEvento updatedCategoria)
        {
            var existingCategoria = await _serviceCategoriaEvento.GetByIdAsync(id);
            if (existingCategoria == null)
            {
                return NotFound();
            }

            existingCategoria.Nombre = updatedCategoria.Nombre;
            
            await _serviceCategoriaEvento.UpdateAsync(existingCategoria);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _serviceCategoriaEvento.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            await _serviceCategoriaEvento.DeleteAsync(id);
            return NoContent();
        }
    }
}

