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

    public Task<Bestelling?> AnnulerenAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Bestelling>> SearchBestelling(string searchValue)
    {
        throw new NotImplementedException();
    }

    public Task<List<Bestelling>> GetBestellingen()
    {
        throw new NotImplementedException();
    }

    public Task<Bestelling?> Annuleren(int id)
    {
        throw new NotImplementedException();
    }
}
