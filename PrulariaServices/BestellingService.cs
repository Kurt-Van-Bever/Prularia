using Prularia.Models;
using Prularia.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
    public async Task AnnulerenAsync(int id)
    {
        await _bestellingRepo.Annuleren(id);
    }
}
