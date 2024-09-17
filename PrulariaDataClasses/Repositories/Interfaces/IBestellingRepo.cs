using Prularia.Models;

namespace Prularia.Repositories;


public interface IBestellingRepo
{
    void Update(Bestelling bestelling);

    Bestelling? Get(int id);
}
