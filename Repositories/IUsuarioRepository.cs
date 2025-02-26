using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        /// Registra un nuevo usuario en la base de datos.
        Task<UsuarioDTOOut> AddUserFromCredentials(LoginDTO loginDTO);
    
    }
}
