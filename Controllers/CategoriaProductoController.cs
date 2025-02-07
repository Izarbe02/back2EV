using Microsoft.AspNetCore.Mvc;
using dosEvAPI.Repositories;
using dosEvAPI.Service;

namespace dosEvAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaProductoController : ControllerBase
    {
        private readonly ICategoriaProductoService _serviceCategoriaProducto;

        public CategoriaProductoController(ICategoriaProductoService service)
        {
            _serviceCategoriaProducto = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaProducto>>> GetCategorias()
        {
            var categorias = await _serviceCategoriaProducto.GetAllAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaProducto>> GetCategoria(int id)
        {
            var categoria = await _serviceCategoriaProducto.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaProducto>> CreateCategoria(CategoriaProducto categoria)
        {
            await _serviceCategoriaProducto.AddAsync(categoria);
            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, CategoriaProducto updatedCategoria)
        {
            var existingCategoria = await _serviceCategoriaProducto.GetByIdAsync(id);
            if (existingCategoria == null)
            {
                return NotFound();
            }

            existingCategoria.Nombre = updatedCategoria.Nombre;
            
            await _serviceCategoriaProducto.UpdateAsync(existingCategoria);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _serviceCategoriaProducto.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            await _serviceCategoriaProducto.DeleteAsync(id);
            return NoContent();
        }
    }
}

