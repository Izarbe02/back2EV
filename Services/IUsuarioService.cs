using dosEvAPI.Models;
using dosEvAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dosEvAPI.Service
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
      Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);

        // Métodos de autenticación
        Task<string> Login(LoginDTO loginDTO);
        Task<string> Register(Usuario usuario);
    }
}
