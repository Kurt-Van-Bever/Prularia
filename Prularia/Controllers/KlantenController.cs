using Microsoft.AspNetCore.Mvc;
using Prularia.Services;
using Prularia.Models;

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
    }
}
