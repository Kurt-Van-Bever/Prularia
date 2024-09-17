using Microsoft.EntityFrameworkCore;
using Prularia.Models;

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
        return await _context.Bestellingen.Include(bestelling => bestelling.Klant).ThenInclude(bestelling => bestelling.Natuurlijkepersoon).ThenInclude(bestelling => bestelling.GebruikersAccount).Include(bestelling => bestelling.BestellingsStatus).ToListAsync();
    }
}
