using Microsoft.AspNetCore.Mvc;
using Prularia.Models;
using Prularia.Services;

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
}
