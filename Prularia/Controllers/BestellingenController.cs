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
    private readonly IHttpContextAccessor _contextAccessor;

    public BestellingenController(BestellingService bestellingService, IHttpContextAccessor httpContextAccessor)
    {
        _bestellingService = bestellingService;
        _contextAccessor = httpContextAccessor;



    }

    [HttpGet]
    public async Task<IActionResult> Index(string searchValue, string zoek, string sorteer)
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
  
    

        

            vm.BestellingItems = await _bestellingService.SearchBestellingAsync(searchValue, zoek, sorteer);
            return View(vm);
        


    }


  
}
