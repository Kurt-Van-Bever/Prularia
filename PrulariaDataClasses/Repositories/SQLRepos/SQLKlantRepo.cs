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

    public async Task<List<Klant>> GetKlantenAsync()
    {
        return await _context.Klanten
            .Include(k => k.Natuurlijkepersoon)
            .ThenInclude(n => n.GebruikersAccount)
            .Include(k => k.Rechtspersoon) 
            .Include(k => k.FacturatieAdres)
            .ThenInclude(fa => fa.Plaats)
            .ToListAsync();
    }   

    public void Update(Klant klant)
    {
        if (klant != null)
        {
            _context.Klanten.Update(klant);
            _context.SaveChanges();
        }
    }

    public Klant? Get(int id) => _context.Klanten.Find(id);


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

    public async Task<Klant?> DisableAsync(int id)
    {
        var klant = await GetKlantAsync(id);

        if (klant != null)
        {
            klant.Natuurlijkepersoon!.GebruikersAccount.Disabled = true;
            await _context.SaveChangesAsync();
        }
    
        return klant;
    }

    public async Task<Klant?> ActivateAsync(int id)
    {
        var klant = await GetKlantAsync(id);

        if (klant != null)
        {
            klant.Natuurlijkepersoon!.GebruikersAccount.Disabled = false;
            await _context.SaveChangesAsync();
        }
    
        return klant;
    }
}
