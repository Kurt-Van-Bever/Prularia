using Prularia.Models;

namespace Prularia.Repositories;

public class DummyKlantRepo : IKlantRepo
{
    public Task<List<Klant>> GetKlantenAsync()
    {
        throw new NotImplementedException();
    }
}
