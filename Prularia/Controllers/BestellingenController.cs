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
    [HttpGet]
    public IActionResult Wijzigen(int id)
    {
        var bestelling = _bestellingService.Get(id);
        return View(bestelling);
    }
    [HttpPost]
    public IActionResult WijzigenDoorvoeren(Bestelling bestelling)
    {
        if (this.ModelState.IsValid)
        {
            _bestellingService.Update(bestelling);
            return RedirectToAction();//verwijzing naar detailpagina)
        }
        return View("Wijzigen", bestelling);
    }
}
