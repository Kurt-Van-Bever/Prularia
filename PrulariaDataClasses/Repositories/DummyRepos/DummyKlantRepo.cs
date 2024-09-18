using Prularia.Models;

namespace Prularia.Repositories;

public class DummyKlantRepo : IKlantRepo
{
    public Task<Contactpersoon?> GetContactpersonenAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Klant?> GetKlantAsync(int id)
    {
        throw new NotImplementedException();
    }
}
