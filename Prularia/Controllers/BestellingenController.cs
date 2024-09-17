using Microsoft.AspNetCore.Mvc;
using Prularia.Services;

namespace Prularia.Controllers;

public class BestellingenController : Controller
{
    private readonly BestellingService _bestellingService;
    public BestellingenController(BestellingService bestellingService)
    {
        _bestellingService = bestellingService;
    }

    public IActionResult Index()
    {
        return View();
    }
}
