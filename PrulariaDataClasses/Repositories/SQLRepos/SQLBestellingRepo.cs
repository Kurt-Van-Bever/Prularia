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

    public async Task<Bestelling?> GetAsync(int id)
    {
        return await _context.Bestellingen
            .Include(b => b.BestellingsStatus)
            .Include(b => b.Betaalwijze)
            .Include(b => b.Klant)
            .Include(b => b.FacturatieAdres)
            .Include(b => b.LeveringsAdres)
            .Include(b => b.Bestellijnen).ThenInclude(l => l.Artikel)
            .FirstOrDefaultAsync(b => b.BestelId == id);
    }
}
