using Prularia.Models;

namespace Prularia.Repositories;

public class SQLBestellingRepo : IBestellingRepo
{
    private readonly PrulariaContext _context;
    public SQLBestellingRepo(PrulariaContext context)
    {
        _context = context;
    }

    public void Update(Bestelling bestelling)
    {
        if (bestelling != null)
        {
            _context.Bestellingen.Update(bestelling);
            _context.SaveChanges();
        }
    }

    public Bestelling? Get(int id) => _context.Bestellingen.Find(id);
}
