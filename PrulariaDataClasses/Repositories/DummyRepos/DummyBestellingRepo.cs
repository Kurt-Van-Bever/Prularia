using Prularia.Models;

namespace Prularia.Repositories;

public class DummyBestellingRepo : IBestellingRepo
{
    public Bestelling? Get(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Bestelling bestelling)
    {
        throw new NotImplementedException();
    }
}
