using Prularia.Models;
using System.Threading.Tasks;

namespace Prularia.Repositories;


public interface IBestellingRepo
{
    //oplijsten alle bestellingen
    public Task<List<Bestelling>> GetBestellingen();
    Task<Bestelling?> GetAsync(int id);
     Task<Bestelling?> Annuleren(int id);
}
