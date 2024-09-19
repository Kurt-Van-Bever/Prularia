using Prularia.Models;
using System.Threading.Tasks;

namespace Prularia.Repositories;


public interface IBestellingRepo
{
    //oplijsten alle bestellingen
    public Task<List<Bestelling>> GetBestellingenAsync();
    
    Task<Bestelling?> GetAsync(int id);
    void Update(Bestelling bestelling);

    Bestelling? Get(int id);
     Task<Bestelling?> Annuleren(int id);
}
