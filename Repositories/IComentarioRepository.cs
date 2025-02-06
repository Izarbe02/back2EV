using Models;
using Microsoft.Data.SqlClient;


namespace dosEvAPI.Repositories{
    public interface IComentarioRepository
    {
        Task<List<Comentario>> GetAllAsync();
        Task<Comentario?> GetByIdAsync(int id);
        Task AddAsync(Comentario comentario);
        Task UpdateAsync(Comentario comentario);
        Task DeleteAsync(int id);
        Task InicializarDatosAsync();
    }
}