using Microsoft.Identity.Client;
using Prularia.Models;

namespace Prularia.Repositories;

public class DummyBestellingRepo : IBestellingRepo
{

 
    public Task<List<Bestelling>> GetBestellingenAsync()
    {
        throw new NotImplementedException();
    }
    public Task<Bestelling?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }
    public Bestelling? Get(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Bestelling bestelling)
    {
        throw new NotImplementedException();
    }

    public Task<Bestelling?> AnnulerenAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Bestelling>> SearchBestelling(string searchValue)
    {
        if (string.IsNullOrEmpty(searchValue))
            searchValue = string.Empty;
        
        var csvData = await File.ReadAllLinesAsync("MOCK_DATA.csv");
        List<Bestelling?> mockList = csvData
                                            .Skip(1)
                                            .Select(x => selecteerData(x))
                                            .ToList();
        Bestelling? selecteerData(string csvLine)
        {
            string[] waardes = csvLine.Split(',');
            if (Array.Exists(waardes, waarde =>
            {
            if (string.IsNullOrEmpty(waarde))
                    return false;
            if (waarde.ToString().ToUpper().StartsWith(searchValue.ToUpper()))
                return true;
            else return 
                    false;
            })) { 
                var bestelling = new Bestelling();
                bestelling.Klant = new Klant();
                bestelling.Klant.Natuurlijkepersoon = new Natuurlijkepersoon();
                bestelling.Klant.Natuurlijkepersoon.GebruikersAccount = new Gebruikersaccount();
                bestelling.BestellingsStatus = new Bestellingsstatus();

                bestelling.BestelId = Convert.ToInt32(waardes[0]);
                bestelling.Besteldatum = Convert.ToDateTime(waardes[1]);
                bestelling.Klant.Natuurlijkepersoon.Voornaam = waardes[2];
                bestelling.Klant.Natuurlijkepersoon.Familienaam = waardes[3];
                bestelling.Klant.Natuurlijkepersoon.GebruikersAccount.Emailadres = waardes[4];
                bestelling.Bedrijfsnaam = waardes[5];
                bestelling.BtwNummer = waardes[6];
                bestelling.BestellingsStatus.Naam = waardes[7];
                return bestelling;

            }
            return null;
        }
        mockList.RemoveAll(item => item == null);
        return (List<Bestelling>)mockList;
    }

    public Task<List<Bestelling>> GetBestellingen()
    {
        throw new NotImplementedException();
    }

    public Task<Bestelling?> Annuleren(int id)
    {
        throw new NotImplementedException();
    }
}
