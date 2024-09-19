using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Prularia.Models;
using Prularia.Services;
using System.Buffers;
using System.Web;

namespace Prularia.Controllers;

public class BestellingenController : Controller
{
    private readonly BestellingService _bestellingService;
    public BestellingenController(BestellingService bestellingService)
    {
        _bestellingService = bestellingService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string searchValue, string zoek, string sorteer)
    {
        var vm = new BestellingenViewModel();

        if (zoek != null)
        {

            vm.BestellingItems = await _bestellingService.SearchBestellingAsync(searchValue, zoek, sorteer);
            return View(vm);
         

        } 
        
           
            vm.BestellingItems = await _bestellingService.SearchBestellingAsync(searchValue, zoek, sorteer);
            return View(vm);
        


    }


  
}
