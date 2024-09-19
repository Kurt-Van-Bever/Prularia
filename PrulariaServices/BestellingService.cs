using Google.Protobuf.WellKnownTypes;
using Prularia.Models;
using Prularia.Repositories;

namespace Prularia.Services;

public class BestellingService
{
    private readonly IBestellingRepo _bestellingRepo;
    public BestellingService(IBestellingRepo bestellingRepo)
    {
        _bestellingRepo = bestellingRepo;
    }

    public async Task<List<Bestelling>> GetBestellingenAsync()
    {
        return await _bestellingRepo.GetBestellingenAsync();
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
    public async Task AnnulerenAsync(int id)
    {
        await _bestellingRepo.Annuleren(id);
    }

    public async Task<List<Bestelling>> SearchBestellingAsync(string searchValue, string searchOptie, string sorteerOptie)
    {

        List<Bestelling> Bestellingen = await _bestellingRepo.SearchBestelling(searchValue, searchOptie);



        if (sorteerOptie == "alfabetisch") {
            return Bestellingen.OrderBy(bestelling => bestelling.Klant.Natuurlijkepersoon?.Voornaam).ThenBy(bestelling => bestelling.Klant.Natuurlijkepersoon?.Familienaam).ToList(); 
        }

        if(sorteerOptie == "datum")
        {
        
            return Bestellingen.OrderByDescending(bestelling => bestelling.Besteldatum).ToList();
        }

        if(sorteerOptie == "status")
        {

            return Bestellingen.OrderBy(bestelling => bestelling.BestellingsStatus.Naam).ToList();
        }

        return Bestellingen;
    }
}
