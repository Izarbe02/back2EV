using Models;

namespace dosEvAPI.Service{public class CategoriaProductoService : ICategoriaProductoService
    {
        private readonly ICategoriaProductoRepository _categoriaProductoRepository;

        public CategoriaProductoService(ICategoriaProductoRepository categoriaProductoRepository)
        {
            _categoriaProductoRepository = categoriaProductoRepository;
        }

        public async Task<List<CategoriaProducto>> GetAllAsync()
        {
            return await _categoriaProductoRepository.GetAllAsync();
        }

        public async Task<CategoriaProducto?> GetByIdAsync(int id)
        {
            return await _categoriaProductoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CategoriaProducto categoriaProducto)
        {
            await _categoriaProductoRepository.AddAsync(categoriaProducto);
        }

        public async Task UpdateAsync(CategoriaProducto categoriaProducto)
        {
            await _categoriaProductoRepository.UpdateAsync(categoriaProducto);
        }

        public async Task DeleteAsync(int id)
        {
            var categoriaProducto = await _categoriaProductoRepository.GetByIdAsync(id);
            if (categoriaProducto == null)
            {
                //return NotFound();
            }
            await _categoriaProductoRepository.DeleteAsync(id);
            //return NoContent();
        }
    }
}
