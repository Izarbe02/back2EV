using Microsoft.AspNetCore.Mvc;
using dosEvAPI.Repositories;
using dosEvAPI.Service;
using Models;

namespace dosEvAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _serviceProducto;

        public ProductoController(IProductoService service)
        {
            _serviceProducto = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var productos = await _serviceProducto.GetAllAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _serviceProducto.GetByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> CreateProducto(Producto producto)
        {
            await _serviceProducto.AddAsync(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, Producto updatedProducto)
        {
            var existingProducto = await _serviceProducto.GetByIdAsync(id);
            if (existingProducto == null)
            {
                return NotFound();
            }

            existingProducto.Nombre = updatedProducto.Nombre;
            existingProducto.Descripcion = updatedProducto.Descripcion;
            existingProducto.Ubicacion = updatedProducto.Ubicacion;
            existingProducto.Imagen = updatedProducto.Imagen;
            existingProducto.IdOrganizador = updatedProducto.IdOrganizador;
            existingProducto.IdCategoria = updatedProducto.IdCategoria;

            await _serviceProducto.UpdateAsync(existingProducto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _serviceProducto.GetByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            await _serviceProducto.DeleteAsync(id);
            return NoContent();
        }
    }
}