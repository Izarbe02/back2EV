using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

public interface IEstablecimientoRepository
{
    Task<List<Establecimiento>> GetAllAsync();
    Task<Establecimiento?> GetByIdAsync(int id);
    Task<Establecimiento> AddAsync(Establecimiento establecimiento);
    Task<Establecimiento> UpdateAsync(Establecimiento establecimiento);
    Task DeleteAsync(int id);
}
