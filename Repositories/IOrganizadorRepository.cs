using Models;
using Microsoft.Data.SqlClient;




namespace dosEvAPI.Repositories{
    public interface IOrganizadorRepository
    {
        Task<List<Organizador>> GetAllAsync();
        Task<Organizador?> GetByIdAsync(int id);
        Task <Organizador> AddAsync(Organizador organizador);
        Task <Organizador>UpdateAsync(Organizador organizador);
        Task DeleteAsync(int id);
    }
}