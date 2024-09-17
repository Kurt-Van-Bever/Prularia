using Prularia.Models;

namespace Prularia.Repositories;

public class SQLKlantRepo : IKlantRepo
{
    private readonly PrulariaContext _context;
    public SQLKlantRepo(PrulariaContext context)
    {
        _context = context;
    }
}
