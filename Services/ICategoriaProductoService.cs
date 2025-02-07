using dosEvAPI.Repositories;
using Models;

namespace dosEvAPI.Service
{
  
    public interface ICategoriaProductoService
    {
        Task<List<CategoriaProducto>> GetAllAsync();
        Task<CategoriaProducto?> GetByIdAsync(int id);
        Task AddAsync(CategoriaProducto categoriaProducto);
        Task UpdateAsync(CategoriaProducto categoriaProducto);
        Task DeleteAsync(int id);
    }
}