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

    public async Task<List<Klant>> GetNatuurlijkePersonenAsync() => await _klantRepo.GetNatuurlijkePersonenAsync();
    public async Task<List<Klant>> GetRechtspersonenAsync() => await _klantRepo.GetRechtspersonenAsync();

    public Klant? Get(int id)
    {
        return _klantRepo.Get(id);
    }

    public void Update(Klant klant)
    {
        _klantRepo.Update(klant);
    }
    public async Task<List<Bestelling?>> GetBestellingenByKlantAsync(int id)
    {
        return await _klantRepo.GetBestellingenByKlantAsync(id);
    }

    public async Task<Klant?> GetKlant(int id) => await _klantRepo.GetKlantAsync(id);

    public async Task<ICollection<Contactpersoon>> GetContactpersonen(int id) 
        => await _klantRepo.GetContactpersonenAsync(id);

    public async Task<Klant?> DisableKlantAsync(int id) 
        => await _klantRepo.DisableKlantAsync(id);
    public async Task<Klant?> ActivateKlantAsync(int id) 
        => await _klantRepo.ActivateKlantAsync(id);
    public async Task<Contactpersoon?> DisableContactpersoonAsync(int id) 
        => await _klantRepo.DisableContactpersoonAsync(id);
    public async Task<Contactpersoon?> ActivateContactpersoonAsync(int id) 
        => await _klantRepo.ActivateContactpersoonAsync(id);
}
