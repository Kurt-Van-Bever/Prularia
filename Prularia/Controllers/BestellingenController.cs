using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Prularia.Services;
using System.Buffers;
using System.Web;
using Prularia.Models;
using Prularia.Filters;
using X.PagedList;
using X.PagedList.Mvc.Core;
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
    public async Task<IActionResult> Index(string? searchValue, string? zoek, string? sorteer, int? page)
    {
        var vm = new BestellingenViewModel();

        if(searchValue != null)
        {
            HttpContext.Session.SetString("searchvalue", searchValue);
        } else
        {
            HttpContext.Session.Remove("searchvalue");
        }

        

        if(zoek != null)
        {
            HttpContext.Session.SetString("zoek", zoek);
        } else
        {
            HttpContext.Session.Remove("zoek");
        }
   
        if(sorteer != null) {
            HttpContext.Session.SetString("sorteer", sorteer);
        } else
        {
            HttpContext.Session.Remove("sorteer");
        }
  
    

        

        var bestellingen /*= vm.BestellingItems */= await _bestellingService.SearchBestellingAsync(searchValue!, zoek!, sorteer!);
        //vm.BestellingItems = bestellingen.ToPagedList((page ?? 1),3);
        ViewBag.pagedList = new PagedList<Bestelling>(bestellingen, (page ?? 1), 3);
        vm.BestellingItems = new PagedList<Bestelling>(bestellingen, (page ?? 1), 3);
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
            bestelling!.Betaald = vm.Betaald;
            bestelling.Bedrijfsnaam = vm.Bedrijfsnaam;
            bestelling.BtwNummer = vm.BtwNummer;
            bestelling.Voornaam = vm.Voornaam;
            bestelling.Familienaam = vm.Familienaam;
            _bestellingService.Update(bestelling);
            return RedirectToAction(nameof(Details), new { id = bestelling.BestelId });
        }
        return View("Wijzigen", vm);
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
