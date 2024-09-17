using Prularia.Models;
using System.Threading.Tasks;

namespace Prularia.Repositories;


public interface IBestellingRepo
{
     Task<Bestelling?> Annuleren(int id);
}
