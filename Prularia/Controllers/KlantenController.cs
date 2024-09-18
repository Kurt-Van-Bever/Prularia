using Microsoft.AspNetCore.Mvc;
using Prularia.Models;
using Prularia.Services;

namespace Prularia.Controllers;

public class KlantenController : Controller
{
    private readonly KlantService _klantService;
    public KlantenController(KlantService klantService)
    {
        _klantService = klantService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Details(int id)
    {
        Klant? klant = await _klantService.GetKlant(id);
        if (klant == null) return NotFound();
        KlantDetailViewModel viewModel = new KlantDetailViewModel()
        {
            KlantId = klant.KlantId,
            Bestellingen = klant.Bestellingen,
            FacturatieAdres = klant.FacturatieAdres,
            LeveringsAdres = klant.LeveringsAdres,
            Natuurlijkepersoon = klant.Natuurlijkepersoon,
            Rechtspersoon = klant.Rechtspersoon,
            Uitgaandeleveringen = klant.Uitgaandeleveringen
        };
        return View(viewModel);
    }

    public async Task<IActionResult> ContactPersonen(int id)
    {
        Contactpersoon? contactpersoon = await _klantService.GetContactpersonen(id);
        if (contactpersoon == null) return NotFound();
        ContactpersonenViewModel viewModel = new ContactpersonenViewModel
        {
            KlantId = contactpersoon.KlantId,
            Voornaam = contactpersoon.Voornaam,
            Familienaam = contactpersoon.Familienaam,
            Functie = contactpersoon.Functie,
            Emailadres = contactpersoon.GebruikersAccount.Emailadres
        };
        return View(viewModel);
    }
}
