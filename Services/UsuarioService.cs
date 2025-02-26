using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dosEvAPI.Repositories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Identity.Client;

namespace dosEvAPI.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
  

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
 
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

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        // public async Task DeleteAsync(int id)
        // {
        //     var usuario = await _usuarioRepository.GetByIdAsync(id);
        //     if (usuario != null)
        //     {
        //         await _usuarioRepository.DeleteAsync(id);
        //     }
        // }
        //  public async Task<string> Login(LoginDTO loginDTO)
        // {
        //     UsuarioDTOOut user = await _usuarioRepository.GetUserFromCredentials(loginDTO);
        //     return _tokenService.GenerateToken(user);
        // }

        // public async Task<string> Register(LoginDTO loginDTO)
        // {
        //     UsuarioDTOOut user = await _usuarioRepository.AddUserFromCredentials(loginDTO);
        //     return _okenService.GenerateToken(user);
        // }
    }
}
