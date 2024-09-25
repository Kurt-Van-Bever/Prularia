using Microsoft.AspNetCore.Mvc;
using Prularia.Models;
using Prularia.Services;
using Prularia.Filters;
using System.Text.Json;
using System.Numerics;

namespace Prularia.Controllers
{
    public class SecurityController : Controller
    {
        public const string SESSION_LOGGEDIN_USER = "LOGGEDIN_USERID";
        private readonly SecurityService _securityService;

        public SecurityController(SecurityService securityService)
        {
            _securityService = securityService;
        }

        public IActionResult Index()
        {
            if (GetSession_LoggedInUser(HttpContext) == null)
                return RedirectToAction(nameof(Login));


            ViewBag.Email = _securityService.GetAccount(GetSession_LoggedInUser(HttpContext).UserId).Emailadres;
            return View();
        }

        public IActionResult Login()
        {
            // already logged in
            if (GetSession_LoggedInUser(HttpContext) != null)
                return RedirectToAction(nameof(BestellingenController.Index), "Bestellingen");

            UserLoginViewModel vm = new();
            return View(vm);
        }

        public async Task<IActionResult> LoginDoorvoeren(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Personeelslid? lid = await _securityService.TryGetPersoneelslidFromLogin(model.Email, model.Password);

                if (lid == null)
                    return View(nameof(Login), model);

                // found user
                List<string> groups = new List<string>();
                foreach (var group in lid.SecurityGroepen)
                    groups.Add(group.Naam);

                SetSession_LoggedInUser(HttpContext, new LoggedInUserData { UserId = lid.PersoneelslidId, SecurityGroepen = groups });
                return RedirectToAction(nameof(Login));
            }
            return View(nameof(Login), model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SESSION_LOGGEDIN_USER);
            return RedirectToAction(nameof(Login));
        }

        public IActionResult NoAccess()
        {
            return View();
        }

        public static void SetSession_LoggedInUser(HttpContext httpContext, LoggedInUserData userData)
        {
            httpContext.Session.SetString(SESSION_LOGGEDIN_USER, JsonSerializer.Serialize(userData));
        }
        public static LoggedInUserData? GetSession_LoggedInUser(HttpContext httpContext)
        {
            string? sessionVar = httpContext.Session.GetString(SESSION_LOGGEDIN_USER);
            if (sessionVar == null) return null;
            return JsonSerializer.Deserialize<LoggedInUserData>(sessionVar);
        }

        [HttpGet]
        public IActionResult PaswoordWijzigen()
        {
            var vm = new PaswoordViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult PaswoordWijzigen(PaswoordViewModel vm)
        {
            if (this.ModelState.IsValid)
            {
                int accountId = GetSession_LoggedInUser(HttpContext).UserId;
                var account = _securityService.GetAccount(accountId);

                if (!_securityService.VerifyPaswoord(vm.OudPaswoord, account!.Paswoord))
                {
                    ViewBag.ErrorMessage = "Foutief paswoord ingegeven.";
                    return View(new PaswoordViewModel());
                }

                if (vm.NieuwPaswoord != vm.NieuwPaswoordConfirmatie)
                {
                    ViewBag.ErrorMessage = "Nieuw paswoord kwam niet overeen met nieuw paswoord confirmatie.";
                    return View(new PaswoordViewModel());
                }

                _securityService.UpdatePassword(accountId,
                    _securityService.EncrypteerPaswoord(vm.NieuwPaswoord));
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }


        public IActionResult Securitygroepen()
        {
            var securitygroepen = _securityService.GetAllSecuritygroepen();
            return View(securitygroepen);
        }

        public IActionResult SecuritygroepDetails(int id)
        {
            var securitygroep = _securityService.GetSecuritygroep(id);
            var members = _securityService.GetPersoneelsledenBySecuritygroepId(id);
            if (securitygroep == null) return NotFound();

            var vm = new SecuritygroepDetailsViewModel()
            {
                Id = securitygroep.SecurityGroepId,
                Naam = securitygroep.Naam,
                Personeelsleden = new List<PersoneelslidAccountViewModel>()
            };

            foreach (var member in members)
            {
                vm.Personeelsleden.Add(new PersoneelslidAccountViewModel()
                {
                    Id = member.PersoneelslidId,
                    Voornaam = member.Voornaam,
                    Familienaam = member.Familienaam,
                    Email = member.PersoneelslidAccount.Emailadres,
                    Securitygroepen = member.SecurityGroepen.ToList(),
                    Disabled = member.PersoneelslidAccount.Disabled
                });
            }

            return View(vm);
        }

        public IActionResult PersoneelsLeden()
        {
            var personeelsleden = _securityService.GetAllPersoneelsleden();
            return View(personeelsleden);
        }
        public IActionResult AdminPage() { return View(); }

        public IActionResult PersoneelslidDetails(int id)
        {
            var personeelslid = _securityService.GetPersoneelslid(id);
            if (personeelslid == null) return NotFound();
            var vm = new PersoneelslidAccountViewModel()
            {
                Id = personeelslid.PersoneelslidId,
                Voornaam = personeelslid.Voornaam,
                Familienaam = personeelslid.Familienaam,
                Securitygroepen = personeelslid.SecurityGroepen.ToList(),
                Email = personeelslid.PersoneelslidAccount.Emailadres,
                Disabled = personeelslid.PersoneelslidAccount.Disabled
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult PersoneelAccountSetDisabled(int personeelslidAccountId, bool disabled)
        {
            bool success = _securityService.TryPersoneelAccountSetDisabled(personeelslidAccountId, disabled);
            if (success)
                return RedirectToAction("~/Security/PersoneelsAccounts");
            else
                return NotFound();
        }

        public IActionResult PersoneelToevoegen()
        {
            var vm = new Gebruikersaccount();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Toevoegen(Gebruikersaccount account)
        {
            if (ModelState.IsValid)
            {
                _securityService.GebruikerToevoegen(account);
            }
            return RedirectToAction("Index");
        }
    }
}
