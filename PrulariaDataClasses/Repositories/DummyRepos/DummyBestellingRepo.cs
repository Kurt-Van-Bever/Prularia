using Prularia.Models;

namespace Prularia.Repositories;

public class DummyBestellingRepo : IBestellingRepo
{
    public Task<Bestelling?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }
}
