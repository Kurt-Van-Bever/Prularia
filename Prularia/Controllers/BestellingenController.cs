using Microsoft.AspNetCore.Mvc;
using Prularia.Services;
using Prularia.Models;
using Prularia.Filters;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Buffers;
using System.IO;
namespace Prularia.Controllers;

[AuthorizationGroup("Cwebsite")]
public class BestellingenController : Controller
{
    private readonly BestellingService _bestellingService;
    private readonly IHttpContextAccessor _contextAccessor;

    private const int PAGINATION_DEFAULT_PAGESIZE = 50;

    public BestellingenController(BestellingService bestellingService, IHttpContextAccessor httpContextAccessor)
    {
        _bestellingService = bestellingService;
        _contextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? searchValue, string? sorteer,
        int? page, int? pageSize = PAGINATION_DEFAULT_PAGESIZE)
    {
        var keuzes = new SelectListItem[] {
            new SelectListItem() { Text = "3", Value = "3" },
            new SelectListItem() { Text = "10", Value = "10" },
            new SelectListItem() { Text = "20", Value = "20" },
            new SelectListItem() { Text = "30", Value = "30" },
            new SelectListItem() { Text = "40", Value = "40" },
            new SelectListItem() { Text = "50", Value = "50" },
            new SelectListItem() { Text = "100", Value = "100" }
        };

        keuzes.FirstOrDefault(p => p.Value == pageSize.ToString()).Selected = true;

        ViewBag.PageSizeKeuze = keuzes;
        ViewBag.pageSize = pageSize;

        if (searchValue != null)
            HttpContext.Session.SetString("searchvalue", searchValue);
        else
            HttpContext.Session.Remove("searchvalue");

        if (sorteer != null)
            HttpContext.Session.SetString("sorteer", sorteer);
        else
            HttpContext.Session.Remove("sorteer");

        var bestellingen = await _bestellingService.SearchBestellingAsync(searchValue!, sorteer!);
        var vm = new List<BestellingenViewModel>();
        string email = string.Empty;
        foreach (var b in bestellingen)
        {
            email = string.Empty;
            if (b.Klant.Natuurlijkepersoon != null)
                email = b.Klant.Natuurlijkepersoon.GebruikersAccount.Emailadres;
            else
            {
                var contactpersoon = b.Klant.Rechtspersoon!.Contactpersonen
                    .FirstOrDefault(c => c.Voornaam == b.Voornaam && c.Familienaam == b.Familienaam);
                if (contactpersoon != null)
                    email = contactpersoon.GebruikersAccount.Emailadres;
            }

            vm.Add(new BestellingenViewModel
            {
                BestelId = b.BestelId,
                Besteldatum = b.Besteldatum,
                Voornaam = b.Voornaam,
                Familienaam = b.Familienaam,
                Emailadres = email,
                Bedrijfsnaam = b.Bedrijfsnaam,
                BtwNummer = b.BtwNummer,
                BestellingsStatus = b.BestellingsStatus,
            });
        }
        return View(vm.ToPagedList((page ?? 1), (pageSize ?? PAGINATION_DEFAULT_PAGESIZE)));
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
        var email = string.Empty;
        if (b.Klant.Natuurlijkepersoon != null)
            email = b.Klant.Natuurlijkepersoon.GebruikersAccount.Emailadres;
        else
        {
            var contactpersoon = b.Klant.Rechtspersoon!.Contactpersonen
                .FirstOrDefault(c => c.Voornaam == b.Voornaam && c.Familienaam == b.Familienaam);
            if (contactpersoon != null)
                email = contactpersoon.GebruikersAccount.Emailadres;
        }
        vm.Email = email;


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

    private async Task<List<Bestelling>> getMockData(string? searchValue)
    {
        if (string.IsNullOrEmpty(searchValue))
            searchValue = string.Empty;

        var csvData = File.ReadAllLines("MOCK_DATA.csv");
        List<Bestelling?> mockList = csvData
                                            .Skip(1)
                                            .Select(x => selecteerData(x))
                                            .ToList();
        Bestelling? selecteerData(string csvLine)
        {
            string[] waardes = csvLine.Split(',');
            if (Array.Exists(waardes, waarde =>
            {
                if (string.IsNullOrEmpty(waarde))
                    return false;
                if (waarde.ToString().ToUpper().StartsWith(searchValue.ToUpper()))
                    return true;
                else return
                        false;
            }))
            {
                var bestelling = new Bestelling();
                bestelling.Klant = new Klant();
                bestelling.Klant.Natuurlijkepersoon = new Natuurlijkepersoon();
                bestelling.Klant.Natuurlijkepersoon.GebruikersAccount = new Gebruikersaccount();
                bestelling.BestellingsStatus = new Bestellingsstatus();

                bestelling.BestelId = Convert.ToInt32(waardes[0]);
                bestelling.Besteldatum = Convert.ToDateTime(waardes[1]);
                bestelling.Klant.Natuurlijkepersoon.Voornaam = waardes[2];
                bestelling.Klant.Natuurlijkepersoon.Familienaam = waardes[3];
                bestelling.Klant.Natuurlijkepersoon.GebruikersAccount.Emailadres = waardes[4];
                bestelling.Bedrijfsnaam = waardes[5];
                bestelling.BtwNummer = waardes[6];
                bestelling.BestellingsStatus.Naam = waardes[7];
                return bestelling;

            }
            return null;
        }
        mockList.RemoveAll(item => item == null);
        return (List<Bestelling>)mockList;
    }
}
