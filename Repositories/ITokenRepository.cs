using Models;
using System.Threading.Tasks;

namespace dosEvAPI.Repositories
{
    public interface ITokenRepository
    {
        Task<Usuario?> LoginAsync(UsuarioLogin authRequest);
    }
}