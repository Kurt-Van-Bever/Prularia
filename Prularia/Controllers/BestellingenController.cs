using Microsoft.AspNetCore.Mvc;
using Prularia.Services;
using Prularia.Models;
using Prularia.Filters;

namespace Prularia.Controllers;

[AuthorizationGroup("Cwebsite")]
public class BestellingenController : Controller
{
    private readonly BestellingService _bestellingService;
    private readonly IHttpContextAccessor _contextAccessor;

    public BestellingenController(BestellingService bestellingService, IHttpContextAccessor httpContextAccessor)
    {
        _bestellingService = bestellingService;
        _contextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? searchValue, string? sorteer)
    {
        var vm = new BestellingenViewModel();

        if (searchValue != null)
        {
            HttpContext.Session.SetString("searchvalue", searchValue);
        }
        else
        {
            HttpContext.Session.Remove("searchvalue");

        }

        if (sorteer != null)
        {
            HttpContext.Session.SetString("sorteer", sorteer);
        }
        else
        {
            HttpContext.Session.Remove("sorteer");
        }

        vm.BestellingItems = await _bestellingService.SearchBestellingAsync(searchValue!, sorteer!);
        return View(vm);

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
        if (b.Klant.Natuurlijkepersoon != null)
        {
            vm.Email = b.Klant.Natuurlijkepersoon.GebruikersAccount.Emailadres;
        }
        else
        {
            vm.Email = b.Klant.Rechtspersoon!.Contactpersonen
                .FirstOrDefault(c => c.Voornaam == vm.Voornaam && c.Familienaam == vm.Familienaam)!
                .GebruikersAccount.Emailadres;
        }

        return View(vm);
    }    

    [HttpPost]
    public async Task<IActionResult> AnnulerenPopupAsync(int id)
    {
        var bestelling = await _bestellingService.GetAsync(id);

        if (bestelling == null)
        {
            return NotFound();
        }

        await _bestellingService.AnnulerenAsync(id);

        return RedirectToAction(nameof(Details), new { id = bestelling.BestelId });
    }

}
