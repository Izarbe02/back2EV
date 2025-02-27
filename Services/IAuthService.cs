using Models;
using dosEvAPI.DTOs;
using dosEvAPI.Models;



namespace dosEvAPI.Services
{
    public interface IAuthService
    {
  
        /// Genera un token JWT para un usuario autenticado.

        Task<string> GenerateToken(UsuarioDTOOut usuarioDTOOut);

  
        /// Verifica las credenciales del usuario y genera un token si son correctas.

        Task<string> Login(LoginDTO loginDTO);

  
        /// Registra un nuevo usuario y genera un token.

        Task<string> Register(LoginDTO loginDTO);

       
        
    }
}
