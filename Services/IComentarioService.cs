using Models;


namespace dosEvAPI.Service
{

    public interface IComentarioService
    {
        Task<List<Comentario>> GetAllAsync();
        Task<Comentario?> GetByIdAsync(int id);
        Task AddAsync(Comentario comentario);
        Task DeleteAsync(int id);
    }
}