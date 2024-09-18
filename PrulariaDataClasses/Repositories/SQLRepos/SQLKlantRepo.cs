using Prularia.Models;

namespace Prularia.Repositories;

public class SQLKlantRepo : IKlantRepo
{
    private readonly PrulariaContext _context;
    public SQLKlantRepo(PrulariaContext context)
    {
        _context = context;
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
