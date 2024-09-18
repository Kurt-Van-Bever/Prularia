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

}
