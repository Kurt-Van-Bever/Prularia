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

    public async Task<Klant?> GetKlant(int id) => await _klantRepo.GetKlantAsync(id);

    public async Task<Contactpersoon?> GetContactpersonen(int id) 
        => await _klantRepo.GetContactpersonenAsync(id);
}
