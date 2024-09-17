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

    public async Task<IActionResult> Details(int id)
    {
        Bestelling? b = await _bestellingService.GetAsync(id);
        if (b == null) return NotFound();

        BestellingDetailViewModel vm = new BestellingDetailViewModel()
        {
            BestelId = b.BestelId,
            Besteldatum = b.Besteldatum,
            Betaald = b.Betaald,
            Betalingscode = b.Betalingscode,
            Annulatie = b.Annulatie,
            Annulatiedatum = b.Annulatiedatum,
            Terugbetalingscode = b.Terugbetalingscode,
            ActiecodeGebruikt = b.ActiecodeGebruikt,
            Bedrijfsnaam = b.Bedrijfsnaam,
            BtwNummer = b.BtwNummer,
            BestellingsStatus = b.BestellingsStatus,
            Betaalwijze = b.Betaalwijze,
            FacturatieAdres = b.FacturatieAdres,
            Voornaam = b.Voornaam,
            Familienaam = b.Familienaam,
            LeveringsAdres = b.LeveringsAdres,

            Bestellijnen = b.Bestellijnen
        };

        return View(vm);
    }
}
