using Prularia.Models;

namespace Prularia.Repositories;

public class DummyKlantRepo : IKlantRepo
{
    public Klant? Get(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Klant klant)
    {
        throw new NotImplementedException();
    }

    public Task<Klant?> GetKlantAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Klant>> GetNatuurlijkePersonenAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Klant>> GetRechtspersonenAsync()
    {
        throw new NotImplementedException();
    }
    //Task<ICollection<Contactpersoon>> GetContactpersonenAsync(int id)
    //{
    //    throw new NotImplementedException();
    //}

    Task<ICollection<Contactpersoon>> IKlantRepo.GetContactpersonenAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Klant?> DisableKlantAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Klant?> ActivateAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Klant?> ActivateKlantAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Contactpersoon?> DisableContactpersoonAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Contactpersoon?> ActivateContactpersoonAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Bestelling?>> GetBestellingenByKlantAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Adres?> CheckAdresAsync(string straat, string huisNummer, string? bus)
    {
        throw new NotImplementedException();
    }

    public int? GetPlaatsId(string postcode)
    {
        throw new NotImplementedException();
    }

    public void AdresToevoegenTabel(Adres adres)
    {
        throw new NotImplementedException();
    }

    public Task<Adres?> CheckAdresAsync(string straat, string huisNummer, int plaatsId)
    {
        throw new NotImplementedException();
    }

    public Adres? CheckAdres(string straat, string huisNummer, int? plaatsId)
    {
        throw new NotImplementedException();
    }

    public void UpdateAdres(Adres adres)
    {
        throw new NotImplementedException();
    }

    public Adres GetAdres(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Klant>> searchNatuurlijkePersonen(string searchValue)
    {
        throw new NotImplementedException();
    }

    public Task<List<Klant>> searchRechtspersonenPersonen(string searchValue)
    {
        throw new NotImplementedException();
    }
}
