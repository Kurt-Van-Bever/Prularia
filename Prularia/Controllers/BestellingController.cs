using Microsoft.AspNetCore.Mvc;
using Prularia.Models;

namespace Prularia.Controllers
{
    public class BestellingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            BestellingDetailViewModel vm = new BestellingDetailViewModel
            {

            };

            return View(vm);
        }
    }
}
