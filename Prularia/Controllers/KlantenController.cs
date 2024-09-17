using Microsoft.AspNetCore.Mvc;
using Prularia.Services;

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
}
