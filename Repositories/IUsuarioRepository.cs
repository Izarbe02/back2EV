using Models;
using Microsoft.Data.SqlClient;
using dosEvAPI.DTOs;


namespace dosEvAPI.Repositories{


    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
        Task <GetUserFromCredentials>(LoginDTO loginDTO);
    }
}