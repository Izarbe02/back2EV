using Models;
using Microsoft.Data.SqlClient;


namespace dosEvAPI.Repositories{
    public interface ICategoriaEventoRepository
    {
        Task<List<CategoriaEvento>> GetAllAsync();
        Task<CategoriaEvento?> GetByIdAsync(int id);
        Task AddAsync(CategoriaEvento categoria);
        Task UpdateAsync(CategoriaEvento categoria);
        Task DeleteAsync(int id);
        Task InicializarDatosAsync();
    }
}