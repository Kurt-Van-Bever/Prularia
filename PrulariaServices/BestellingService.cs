using Prularia.Models;
using Prularia.Repositories;
using Prularia.Models;

namespace Prularia.Services;

public class BestellingService
{
    private readonly IBestellingRepo _bestellingRepo;
    public BestellingService(IBestellingRepo bestellingRepo)
    {
        _bestellingRepo = bestellingRepo;
    }

    public async Task<List<Bestelling>> getBestellingenAsync()
    {
        return await _bestellingRepo.GetBestellingen();
    }

    public async Task<Bestelling?> GetAsync(int id)
    {
        return await _bestellingRepo.GetAsync(id);
    }

    public void Update(Bestelling bestelling)
    {
        _bestellingRepo.Update(bestelling);
    }
    public Bestelling? Get(int id)
    {
        return _bestellingRepo.Get(id);
    }
}
