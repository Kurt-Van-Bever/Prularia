using Microsoft.EntityFrameworkCore;
using Prularia.Models;
using System.Buffers;

namespace Prularia.Repositories;

public class SQLBestellingRepo : IBestellingRepo
{
    private readonly PrulariaContext _context;
    public SQLBestellingRepo(PrulariaContext context)
    {
        _context = context;
    }

    public async Task<List<Bestelling>> GetBestellingen()
    {
        return await _context.Bestellingen
            .Include(bestelling => bestelling.Klant)
            .ThenInclude(bestelling => bestelling.Natuurlijkepersoon)
            .ThenInclude(bestelling => bestelling.GebruikersAccount)
            .Include(bestelling => bestelling.BestellingsStatus).ToListAsync();

    }

    public async Task<List<Bestelling>> SearchBestelling(string searchValue, string ZoekOptie)
    {
        if(ZoekOptie == "klantnaam")
        {
            return await _context.Bestellingen
              .Include(bestelling => bestelling.Klant)
              .ThenInclude(bestelling => bestelling.Natuurlijkepersoon)
              .ThenInclude(bestelling => bestelling.GebruikersAccount)
              .Include(bestelling => bestelling.BestellingsStatus)
              .Where(bestelling => bestelling.Klant.Natuurlijkepersoon.Voornaam.ToUpper().Contains(searchValue.ToUpper())).ToListAsync();
        } else
        {

            return await _context.Bestellingen
             .Include(bestelling => bestelling.Klant)
             .ThenInclude(bestelling => bestelling.Natuurlijkepersoon)
             .ThenInclude(bestelling => bestelling.GebruikersAccount)
             .Include(bestelling => bestelling.BestellingsStatus).ToListAsync();
        }
   
    }
}
