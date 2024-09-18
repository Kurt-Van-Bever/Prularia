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

    [HttpGet]
    public IActionResult Wijzigen(int id)
    {
        var bestelling = _bestellingService.Get(id);
        if (bestelling == null) return NotFound();

        var vm = new BestellingWijzigenViewModel();
        vm.BestelId = bestelling.BestelId;
        vm.Betaald = bestelling.Betaald;
        vm.Bedrijfsnaam = bestelling.Bedrijfsnaam;
        vm.BtwNummer = bestelling.BtwNummer;
        vm.Voornaam = bestelling.Voornaam;
        vm.Familienaam = bestelling.Familienaam;

        return View(vm);
    }

    [HttpPost]
    public IActionResult WijzigenDoorvoeren(BestellingWijzigenViewModel vm)
    {
        if (this.ModelState.IsValid)
        {
            var bestelling = _bestellingService.Get(vm.BestelId);
            bestelling.Betaald = vm.Betaald;
            bestelling.Bedrijfsnaam = vm.Bedrijfsnaam;
            bestelling.BtwNummer = vm.BtwNummer;
            bestelling.Voornaam = vm.Voornaam;
            bestelling.Familienaam = vm.Familienaam;
            _bestellingService.Update(bestelling);
            return RedirectToAction(nameof(Details), new { id = bestelling.BestelId });
        }
        return View("Wijzigen", vm);
    }


    //[HttpPost]
    //public async Task<IActionResult> AnnulerenPopup(int id)
    //{
    //    var bestelling = await _bestellingService.GetAsync(id);
    //    await _bestellingService.AnnulerenAsync(id);

    //    return RedirectToAction("Details", id=id);
    //}

    [HttpPost]
    public async Task<IActionResult> AnnulerenPopup(int id)
    {
        var bestelling = await _bestellingService.GetAsync(id);

        if (bestelling == null)
        {
            return NotFound();  // Of geef een gebruikersvriendelijke foutmelding terug
        }

        await _bestellingService.AnnulerenAsync(id);

        return RedirectToAction(nameof(Details), new { id = bestelling.BestelId });
    }
}
