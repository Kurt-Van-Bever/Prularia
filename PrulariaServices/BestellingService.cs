using Prularia.Repositories;

namespace Prularia.Services;

public class BestellingService
{
    private readonly IBestellingRepo _bestellingRepo;
    public BestellingService(IBestellingRepo bestellingRepo)
    {
        _bestellingRepo = bestellingRepo;
    }
}
