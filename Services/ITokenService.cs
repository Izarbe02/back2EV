using dosEvAPI.DTOs;

namespace dosEvAPI.Service
{
    public interface ITokenService
    {
        string GenerateToken(UsuarioDTOOut usuarioDTOOut);
    }
}
