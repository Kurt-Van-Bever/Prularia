using Prularia.Models;

namespace Prularia.Repositories;

public class DummyBestellingRepo : IBestellingRepo
{

 
    public Task<List<Bestelling>> GetBestellingenAsync()
    {
        throw new NotImplementedException();
    }
    public Task<Bestelling?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }
    public Bestelling? Get(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Bestelling bestelling)
    {
        throw new NotImplementedException();
    }

    public Task<Bestelling?> AnnulerenAsync(int id)
    {
        throw new NotImplementedException();
    }
}
