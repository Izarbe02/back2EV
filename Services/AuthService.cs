using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using dosEvAPI.Repositories;
using dosEvAPI.Models;
using dosEvAPI.DTOs;

namespace dosEvAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthService(IUsuarioRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(UsuarioDTOOut usuarioDTOOut)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioDTOOut._idUSuario.ToString()),
                    new Claim(ClaimTypes.Email, usuarioDTOOut._correo)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return await Task.FromResult(tokenHandler.WriteToken(token));
        }

     
        /// Verifica las credenciales del usuario y genera un token si son correctas.
                
                    public async Task<string> Login(LoginDTO loginDTO)
            {
                var user = await _repository.GetUserFromCredentials(loginDTO);
                if (user == null)
                {
                    throw new KeyNotFoundException("Credenciales inválidas.");
                }

                var userDTO = new UsuarioDTOOut
                {
                    _idUSuario = user._idUSuario,
                    _correo = user._correo
                };

                return await GenerateToken(userDTO);
            }

            public async Task<string> Register(LoginDTO loginDTO)
            {
                var newUser = new Usuario
                {
                    Username = loginDTO._username,
                    Email = loginDTO._email,
                    Contrasenia = loginDTO._password
                };

                await _repository.AddAsync(newUser);

                var userDTO = new UsuarioDTOOut
                {
                    _idUSuario = newUser.Id,
                    _correo = newUser.Email
                };

                return await GenerateToken(userDTO);
            }

                }
            }
