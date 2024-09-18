using Microsoft.EntityFrameworkCore;
using Prularia.Models;

namespace Prularia.Repositories;

public class SQLKlantRepo : IKlantRepo
{
    private readonly PrulariaContext _context;
    public SQLKlantRepo(PrulariaContext context)
    {
        _context = context;
    }

    public async Task<Contactpersoon?> GetContactpersonenAsync(int id)
    {
        return await _context.Contactpersonen
            .Include(c => c.GebruikersAccount)
            .FirstOrDefaultAsync(k => k.KlantId == id);
    }

    public async Task<Klant?> GetKlantAsync(int id)
    {
        return await _context.Klanten
            .Include(k => k.Natuurlijkepersoon).ThenInclude(n => n.GebruikersAccount)
            .Include(k => k.Rechtspersoon)
            .Include(k => k.FacturatieAdres).ThenInclude(f => f.Plaats)
            .Include(k => k.LeveringsAdres).ThenInclude(l => l.Plaats)
            .FirstOrDefaultAsync(k => k.KlantId == id);
    }
}
