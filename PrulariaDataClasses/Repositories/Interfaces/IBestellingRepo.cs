using Prularia.Models;

namespace Prularia.Repositories;


public interface IBestellingRepo
{
    Task<Bestelling?> GetAsync(int id);
    void Update(Bestelling bestelling);

    Bestelling? Get(int id);
}
