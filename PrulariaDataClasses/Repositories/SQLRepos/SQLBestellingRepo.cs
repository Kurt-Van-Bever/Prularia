using Prularia.Models;

namespace Prularia.Repositories;

public class SQLBestellingRepo : IBestellingRepo
{
    private readonly PrulariaContext _context;
    public SQLBestellingRepo(PrulariaContext context)
    {
        _context = context;
    }

    public  async Task<Bestelling?> Annuleren(int id)
    {
        var bestelling = await _context.Bestellingen.FindAsync(id);
        _context.SaveChangesAsync();
        return bestelling;
    }
}
