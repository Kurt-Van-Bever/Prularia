using Prularia.Models;

namespace Prularia.Repositories;

public interface IKlantRepo
{
    void Update(Klant klant);

    Klant? Get(int id);

    Task<List<Klant>> GetNatuurlijkePersonenAsync();
    Task<List<Klant>> GetRechtspersonenAsync();
    Task<Klant?> GetKlantAsync(int id);
    Task<Contactpersoon?> GetContactpersonenAsync(int id);
}
