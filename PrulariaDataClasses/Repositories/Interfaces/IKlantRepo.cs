using Prularia.Models;

namespace Prularia.Repositories;

public interface IKlantRepo
{
    void Update(Klant klant);

    Klant? Get(int id);

    Task<List<Klant>> GetKlantenAsync();
    Task<Klant?> GetKlantAsync(int id);
    Task<ICollection<Contactpersoon>> GetContactpersonenAsync(int id);
    //Task<Contactpersoon?> GetContactpersonenAsync(int id);
    Task<Klant?> DisableKlantAsync(int id);
    Task<Klant?> ActivateKlantAsync(int id);

    Task<Contactpersoon?> DisableContactpersoonAsync(int id);
    Task<Contactpersoon?> ActivateContactpersoonAsync(int id);
}
