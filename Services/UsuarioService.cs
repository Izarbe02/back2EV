using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dosEvAPI.DTOs;
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
        private readonly IConfiguration _configuration;

        public UsuarioService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
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
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario != null)
            {
                await _usuarioRepository.DeleteAsync(id);
            }
        }

        private string GenerateToken(UsuarioDTOOut usuarioDTOOut)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JwtSettings:ValidIssuer"],
                Audience = _configuration["JwtSettings:ValidAudience"],
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioDTOOut.Id.ToString()),
                    new Claim(ClaimTypes.Email, usuarioDTOOut.email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        public async Task<string> Login(LoginDTO loginDTO)
        {
            UsuarioDTOOut user = await _usuarioRepository.GetUserFromCredentials(loginDTO);
            return /*await*/  GenerateToken(user);

        }

        public async Task<string> Register(LoginDTO loginDTO){
            UsuarioDTOOut user  = await _usuarioRepository.AddUserFromCredentials(loginDTO);
            return /*await*/ GenerateToken(user);
        }
    }
}
