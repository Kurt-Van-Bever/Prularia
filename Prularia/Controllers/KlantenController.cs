using Microsoft.AspNetCore.Mvc;
using Prularia.Models;
using Prularia.Services;
using Prularia.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prularia.Controllers;

public class KlantenController : Controller
{
    private readonly KlantService _klantService;
    public KlantenController(KlantService klantService)
    {
        _klantService = klantService;
    }

    public async Task<IActionResult> Index()
    {
        var model = new KlantenViewModel();
        model.KlantItems = await _klantService.GetKlantenAsync();

        return View(model);
    }

    public IActionResult AdresWijzigen(int id)
    {
        var klant = _klantService.Get(id);
        if (klant == null) return NotFound();

        var vm = new AdresWijzigenViewModel();
        vm.KlantId = klant.KlantId;
        vm.FacturatieAdres = klant.FacturatieAdres;
        vm.LeveringsAdres = klant.LeveringsAdres;

        return View(vm);
    }

    [HttpPost]
    public IActionResult WijzigingDoorvoeren(AdresWijzigenViewModel vm)
    {
        if (this.ModelState.IsValid)
        {
            var klant = _klantService.Get(vm.KlantId);
            klant.FacturatieAdres = vm.FacturatieAdres;
            klant.LeveringsAdres= vm.LeveringsAdres;
            _klantService.Update(klant);
            return RedirectToAction(nameof(Details), new { id = vm.KlantId });
        }
        return View("Wijzigen", vm);
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
        ICollection<Contactpersoon> contactpersonen = await _klantService.GetContactpersonen(id);
        if (contactpersonen == null) return NotFound();
        ICollection<ContactpersonenViewModel> contacten = new List<ContactpersonenViewModel>();
        
        foreach(Contactpersoon c in contactpersonen)
        {
            contacten.Add(new ContactpersonenViewModel()
            {
                Voornaam = c.Voornaam,
                Familienaam = c.Familienaam,
                Functie = c.Functie,
                Emailadres = c.GebruikersAccount.Emailadres
            });
            
        }
        ViewBag.KlantId = id;
        return View(contacten);
    }

    [HttpPost]
    public async Task<IActionResult> DisabelenPopupAsync(int id)
    {
        var klant = await _klantService.DisableAsync(id);
        if (klant != null)
            return RedirectToAction(nameof(Details), new { id = klant.KlantId });
        else 
            return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ActivatePopupAsync(int id)
    {
        var klant = await _klantService.ActivateAsync(id);
        if (klant != null)
            return RedirectToAction(nameof(Details), new { id = klant.KlantId });
        else 
            return NotFound();
    }
}
