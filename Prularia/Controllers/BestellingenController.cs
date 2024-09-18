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

    [HttpGet]
    public async Task<IActionResult> Index()
    {
       
            BestellingenViewModel vm = new BestellingenViewModel();
            vm.BestellingItems = await _bestellingService.GetBestellingenAsync();
         
        
        return View(vm);
    }

  
}
