
using Models;
using dosEvAPI.Repositories;

namespace dosEvAPI.Service{

public class TematicaService : ITematicaService
{
    private readonly ITematicaRepository _tematicaRepository;

    public TematicaService(ITematicaRepository tematicaRepository)
    {
        _tematicaRepository = tematicaRepository;
    }

    public async Task<List<Tematica>> GetAllAsync()
    {
        return await _tematicaRepository.GetAllAsync();
    }

    public async Task<Tematica?> GetByIdAsync(int id)
    {
        return await _tematicaRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Tematica tematica)
    {
        await _tematicaRepository.AddAsync(tematica);
    }

    public async Task UpdateAsync(Tematica tematica)
    {
        await _tematicaRepository.UpdateAsync(tematica);
    }

    public async Task DeleteAsync(int id)
    {
        await _tematicaRepository.DeleteAsync(id);
    }
}
}