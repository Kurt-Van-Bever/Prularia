using Prularia.Models;

namespace Prularia.Repositories;

public interface IKlantRepo
{
    void Update(Klant klant);

    Klant? Get(int id);

    Task<List<Klant>> GetNatuurlijkePersonenAsync();
    Task<List<Klant>> searchNatuurlijkePersonen(string searchValue);


    Task<List<Klant>> GetRechtspersonenAsync();
    Task<List<Klant>> searchRechtspersonenPersonen(string searchValue);


    Task<Klant?> GetKlantAsync(int id);
    Task<ICollection<Contactpersoon>> GetContactpersonenAsync(int id);
    //Task<Contactpersoon?> GetContactpersonenAsync(int id);
    Task<Klant?> DisableKlantAsync(int id);
    Task<Klant?> ActivateKlantAsync(int id);

    Task<Contactpersoon?> DisableContactpersoonAsync(int id);
    Task<Contactpersoon?> ActivateContactpersoonAsync(int id);
    Task<List<Bestelling?>> GetBestellingenByKlantAsync(int id);
}
