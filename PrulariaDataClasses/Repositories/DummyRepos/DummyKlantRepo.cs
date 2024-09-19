using Prularia.Models;

namespace Prularia.Repositories;

public class DummyKlantRepo : IKlantRepo
{
    public Klant? Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Klant>> GetKlantenAsync()
    {
        throw new NotImplementedException();
    }

    public void Update(Klant klant)
    {
        throw new NotImplementedException();
    }

    public Task<Klant?> GetKlantAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<ICollection<Contactpersoon>> IKlantRepo.GetContactpersonenAsync(int id)
    {
        throw new NotImplementedException();
    }
}
