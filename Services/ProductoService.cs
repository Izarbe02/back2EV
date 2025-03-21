using dosEvAPI.Repositories;
using Models;

namespace dosEvAPI.Service
{        public class ProductoService : IProductoService
        {
            private readonly IProductoRepository _productoRepository;

            public ProductoService(IProductoRepository productoRepository)
            {
                _productoRepository = productoRepository;
            }

            public async Task<List<Producto>> GetAllAsync()
            {
                return await _productoRepository.GetAllAsync();
            }

            public async Task<Producto?> GetByIdAsync(int id)
            {
                return await _productoRepository.GetByIdAsync(id);
            }

            public async Task AddAsync(Producto producto)
            {
                await _productoRepository.AddAsync(producto);
            }

            public async Task UpdateAsync(Producto producto)
            {
                await _productoRepository.UpdateAsync(producto);
            }

            public async Task DeleteAsync(int id)
            {
                var producto = await _productoRepository.GetByIdAsync(id);
                if (producto == null)
                {
                    //return NotFound();
                }
                await _productoRepository.DeleteAsync(id);
                //return NoContent();
            }
        }
    }
