using Prularia.Models;

namespace Prularia.Repositories;

public interface IKlantRepo
{
    public Task<List<Klant>> GetKlantenAsync();
}
