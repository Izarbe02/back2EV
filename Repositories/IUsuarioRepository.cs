using Models;
using dosEvAPI.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace dosEvAPI.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
         Task<UsuarioDTOOut> GetUserFromCredentials(LoginDTO loginDTO);
        Task<UsuarioDTOOut> AddUserFromCredentials(LoginDTO loginDTO);
    }
}
