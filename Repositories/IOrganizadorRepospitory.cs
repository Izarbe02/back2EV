using Models;
using Microsoft.Data.SqlClient;


namespace dosEvAPI.Repositories{
    public interface IOrganizadorRepository
    {
        Task<List<IOrganizador>> GetAllAsync();
        Task<IOrganizador?> GetByIdAsync(int id);
        Task <IOrganizador> AddAsync(Organizador organizador);
        Task <IOrganizador>UpdateAsync(IOrganizador establecimiento);
        Task DeleteAsync(int id);
    }
}