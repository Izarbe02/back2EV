using dosEvAPI.Repositories;
using Models;

namespace dosEvAPI.Service
{    public interface IUsuarioService
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario> GetByUsernameAsync(string username);

        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
    }
}