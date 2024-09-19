using Prularia.Models;

namespace Prularia.Repositories;

public class DummyBestellingRepo : IBestellingRepo
{

 
    public Task<List<Bestelling>> GetBestellingen()
    {
        throw new NotImplementedException();
    }

    public Task<List<Bestelling>> SearchBestelling(string searchValue, string ZoekOptie)
    {
        throw new NotImplementedException();
    }
}
