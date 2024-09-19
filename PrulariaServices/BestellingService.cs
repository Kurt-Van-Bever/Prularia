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
        return await _bestellingRepo.GetBestellingen();
    }

    public async Task<List<Bestelling>> SearchBestellingAsync(string searchValue, string searchOptie, string sorteerOptie)
    {

        var Bestellingen = await _bestellingRepo.SearchBestelling(searchValue, searchOptie);

            // < option value = "datum" > Datum </ option >
            //< option value = "alfabetisch" > Alfabetisch </ option >
            //< option value = "status" > Status </ option >

        if (sorteerOptie == "alfabetisch") {
            Bestellingen.OrderBy(bestelling => bestelling.Klant.Natuurlijkepersoon?.Voornaam).ThenBy(bestelling => bestelling.Klant.Natuurlijkepersoon?.Familienaam);
            return Bestellingen;
        }

        if(sorteerOptie == "datum")
        {
            Bestellingen.OrderBy(bestelling => bestelling.Besteldatum);
            return Bestellingen;
        }

        if(sorteerOptie == "status")
        {
            Bestellingen.OrderBy(bestelling => bestelling.BestellingsStatus);
        }

        return Bestellingen;
    }
}
