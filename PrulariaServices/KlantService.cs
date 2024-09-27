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

    public Adres? CheckAdres(string straat, string huisNummer, int? plaatsId)
    {
        return  _klantRepo.CheckAdres(straat, huisNummer, plaatsId);
    }


    public int? GetPlaatsId(string postcode)
    {
        return _klantRepo.GetPlaatsId(postcode);
    } 
    public void AdresToevoegenTabel(Adres adres)
    {
        _klantRepo.AdresToevoegenTabel(adres);
    }
    public void UpdateAdres(Adres adres)
    {
        _klantRepo.UpdateAdres(adres);
    }
    public Adres GetAdres(int id)
    {
       return  _klantRepo.GetAdres(id);
    }

    public async Task<List<Klant>> searchNatuurlijkePersoonAsync(string searchValue, string sorteerOptie)
    {

        List<Klant> klanten = await _klantRepo.searchNatuurlijkePersonen(searchValue);



        if (sorteerOptie == "alfabetisch")
        {
           return klanten.OrderBy(klant => klant.Natuurlijkepersoon?.Voornaam).ThenBy(klant => klant.Natuurlijkepersoon?.Familienaam).ToList();
        }

        if (sorteerOptie == "postcode")
            return klanten.OrderBy(klant => klant.FacturatieAdres.Plaats.Postcode).ToList();


        return klanten;
    }

    public async Task<List<Klant>> searcRechtsPersonenAsync(string searchValue, string sorteerOptie)
    {

        List<Klant> klanten = await _klantRepo.searchRechtspersonenPersonen(searchValue);

        if (sorteerOptie == "alfabetisch")
        {
            return klanten.OrderBy(klant => klant.Rechtspersoon!.Naam).ToList();
        }

        if (sorteerOptie == "postcode")
            return klanten.OrderBy(klant => klant.FacturatieAdres.Plaats.Postcode).ToList();


        return klanten;
    }
}



  


