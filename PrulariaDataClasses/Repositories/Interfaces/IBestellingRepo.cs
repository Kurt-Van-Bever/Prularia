using Prularia.Models;

namespace Prularia.Repositories;

public interface IBestellingRepo
{
    //oplijsten alle bestellingen
    public Task<List<Bestelling>> GetBestellingen();
    Task<Bestelling?> GetAsync(int id);
    void Update(Bestelling bestelling);

    Bestelling? Get(int id);
}
