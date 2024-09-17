using Prularia.Models;

namespace Prularia.Repositories;

public class SQLBestellingRepo : IBestellingRepo
{
    private readonly PrulariaContext _context;
    public SQLBestellingRepo(PrulariaContext context)
    {
        _context = context;
    }
}
