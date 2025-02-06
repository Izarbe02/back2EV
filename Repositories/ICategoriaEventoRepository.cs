using Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteAPI.Repositories
{
    public interface ICategoriaProductoRepository
    {
        Task<List<CategoriaProducto>> GetAllAsync();
        Task<CategoriaProducto?> GetByIdAsync(int id);
        Task AddAsync(CategoriaProducto categoria);
        Task UpdateAsync(CategoriaProducto categoria);
        Task DeleteAsync(int id);
        Task InicializarDatosAsync();
    }
}