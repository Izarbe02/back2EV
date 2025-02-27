using dosEvAPI.DTOs;
using dosEvAPI.Models;

namespace dosEvAPI.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);

        // Métodos para autenticación
        Task<UsuarioDTOOut?> GetUserFromCredentials(LoginDTO loginDTO);
        Task<UsuarioDTOOut> AddUserFromCredentials(LoginDTO loginDTO);
    }
}
