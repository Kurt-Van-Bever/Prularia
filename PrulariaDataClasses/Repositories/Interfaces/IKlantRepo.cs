using Prularia.Models;

namespace Prularia.Repositories;

public interface IKlantRepo
{
    Task<Klant?> GetKlantAsync(int id);
    Task<Contactpersoon?> GetContactpersonenAsync(int id);
}
