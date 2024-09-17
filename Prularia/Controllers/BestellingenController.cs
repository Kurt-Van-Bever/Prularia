using Microsoft.AspNetCore.Mvc;
using Prularia.Models;
using Prularia.Services;

namespace Prularia.Controllers;

public class BestellingenController : Controller
{
    private readonly BestellingService _bestellingService;
    public BestellingenController(BestellingService bestellingService)
    {
        _bestellingService = bestellingService;
    }

    public async Task<IActionResult> Index()
    {
        BestellingenViewModel model = new BestellingenViewModel();
        model.BestellingItems = await _bestellingService.getBestellingenAsync();
        return View(model);
    }
}
