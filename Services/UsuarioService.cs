using dosEvAPI.Repositories;
using dosEvAPI.Models;
using dosEvAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using dosEvAPI.Services;

namespace dosEvAPI.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService; // Inyección de dependencia para autenticación

        public UsuarioService(IUsuarioRepository usuarioRepository, IAuthService authService)
        {
            _usuarioRepository = usuarioRepository;
            _authService = authService;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }

        // 🔹 Métodos de autenticación delegados a `AuthService`
        public async Task<string> Login(LoginDTO loginDTO)
        {
            return await _authService.Login(loginDTO);
        }
public async Task<string> Register(Usuario usuario)
{
    // Convertir Usuario a LoginDTO antes de pasarlo a AuthService
    var loginDTO = new LoginDTO
    {
        _username = usuario.Username,
        _email = usuario.Email,
        _password = usuario.Contrasenia
    };

    return await _authService.Register(loginDTO);
}

    }
}
