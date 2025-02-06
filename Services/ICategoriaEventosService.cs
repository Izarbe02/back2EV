using Models;


namespace dosEvAPI.Service
{
        public interface ICategoriaEventoService
    {
        Task<List<CategoriaEvento>> GetAllAsync();
        Task<CategoriaEvento?> GetByIdAsync(int id);
        Task AddAsync(CategoriaEvento categoriaEvento);
        Task UpdateAsync(CategoriaEvento categoriaEvento);
        Task DeleteAsync(int id);
    }
}