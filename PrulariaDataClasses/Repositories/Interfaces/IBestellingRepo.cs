using Prularia.Models;

namespace Prularia.Repositories;

public interface IBestellingRepo
{
    //oplijsten alle bestellingen
    public Task<List<Bestelling>> GetBestellingen();

    public Task<List<Bestelling>> SearchBestelling(string searchValue, string ZoekOptie);
}
