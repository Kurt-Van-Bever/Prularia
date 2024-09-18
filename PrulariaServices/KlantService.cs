using Prularia.Models;
using Prularia.Repositories;

namespace Prularia.Services;

public class KlantService
{
    private readonly IKlantRepo _klantRepo;
    public KlantService(IKlantRepo klantRepo)
    {
        _klantRepo = klantRepo;
    }

    public async Task<List<Klant>> GetKlantenAsync()
    {
        return await _klantRepo.GetKlantenAsync();
    }

    public Klant? Get(int id)
    {
        return _klantRepo.Get(id);
    }

    public void Update(Klant klant)
    {
        _klantRepo.Update(klant);
    }
}
