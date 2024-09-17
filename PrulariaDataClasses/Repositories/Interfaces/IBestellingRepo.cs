using Prularia.Models;

namespace Prularia.Repositories;

public interface IBestellingRepo
{
    //oplijsten alle bestellingen
    public Task<List<Bestelling>> GetBestellingen();
}
