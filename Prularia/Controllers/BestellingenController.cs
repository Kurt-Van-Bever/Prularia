using Microsoft.AspNetCore.Mvc;
using Prularia.Services;
using Prularia.Models;

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

    public IActionResult Details(int id)
    {
        var bestelling = BestellingService.Find(id);
        return View(bestelling);
    }

    [HttpPost]
    public IActionResult AnnulerenPopup(int id)
    {
        var bestelling = BestellingService.Find(id);
        _bestellingService.AnnulerenAsync(id);

        return RedirectToAction(nameof(Details));
    }
}
