using Microsoft.AspNetCore.Mvc;
using Prularia.Models;
using Prularia.Services;
using Prularia.Filters;
using System.Text.Json;
using System.Numerics;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Prularia.Controllers;


public class SecurityController : Controller
{
    public const string SESSION_LOGGEDIN_USER = "LOGGEDIN_USERID";
    private readonly SecurityService _securityService;

    private const int PAGINATION_DEFAULT_PAGESIZE = 5;

    public SecurityController(SecurityService securityService)
    {
        _securityService = securityService;
    }

    [AuthorizationGroup("Cwebsite")]
    public IActionResult Index()
    {
        ViewBag.Email = _securityService.GetAccount(GetSession_LoggedInUser(HttpContext)!.UserId)!.Emailadres;
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

            HttpContext.Session.SetString("UserName", $"{lid.Voornaam} {lid.Familienaam}");
            HttpContext.Session.SetString("Email", lid.PersoneelslidAccount.Emailadres);

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
        HttpContext.Session.Clear();
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

    [AuthorizationGroup("Cwebsite")]
    [HttpGet]
    public IActionResult PaswoordWijzigen()
    {
        var vm = new PaswoordViewModel();
        return View(vm);
    }

    [AuthorizationGroup("Cwebsite")]
    [HttpPost]
    public IActionResult PaswoordWijzigen(PaswoordViewModel vm)
    {
        if (this.ModelState.IsValid)
        {
            int accountId = GetSession_LoggedInUser(HttpContext)!.UserId;

            var account = _securityService.GetAccount(accountId);

            if (!_securityService.VerifyPaswoord(vm.OudPaswoord!, account!.Paswoord))
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
                _securityService.EncrypteerPaswoord(vm.NieuwPaswoord!));
            return RedirectToAction(nameof(Index));
        }
        return View(vm);
    }

    [AuthorizationGroup("Cwebsite")]
    public IActionResult Securitygroepen()
    {
        var securitygroepen = _securityService.GetAllSecuritygroepen();
        return View(securitygroepen);
    }

    [AuthorizationGroup("Cwebsite")]
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

    [AuthorizationGroup("Cwebsite")]
    public async Task<IActionResult> PersoneelsLeden(string? searchValue, string? sorteer, int? page, int? pageSize = PAGINATION_DEFAULT_PAGESIZE)
    {

        if (searchValue != null)
        {
            HttpContext.Session.SetString("searchvaluePersoneel", searchValue);
        }
        else
        {
            HttpContext.Session.Remove("searchvaluePersoneel");

        }


        var keuzes = new SelectListItem[] {
            new SelectListItem() { Text = "5", Value = "5" },
            new SelectListItem() { Text = "10", Value = "10" },
            new SelectListItem() { Text = "20", Value = "20" },
            new SelectListItem() { Text = "30", Value = "30" },
            new SelectListItem() { Text = "40", Value = "40" },
            new SelectListItem() { Text = "50", Value = "50" },
            new SelectListItem() { Text = "100", Value = "100" }
        };


        keuzes.FirstOrDefault(p => p.Value == pageSize.ToString()).Selected = true;

        ViewBag.PageSizeKeuze = keuzes;
        ViewBag.pageSize = pageSize;


        var personeelsleden = await _securityService.SearchPersoneelslid(searchValue!, sorteer!);

        //.ToPagedList((page ?? 1), (pageSize ?? PAGINATION_DEFAULT_PAGESIZE));


        return View(new PagedList<Personeelslid>(personeelsleden, (page ?? 1), (pageSize ?? PAGINATION_DEFAULT_PAGESIZE)));

    }



    [AuthorizationGroup("Cwebsite")]
    public IActionResult AdminPage() { return View(); }

    [AuthorizationGroup("Cwebsite")]
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
    [AuthorizationGroup("Cwebsite")]
    public IActionResult PersoneelAccountSetDisabled(int personeelslidAccountId, bool disabled)
        {
            bool success = _securityService.TryPersoneelAccountSetDisabled(personeelslidAccountId, disabled);
            if (success)
            {
                var account = _securityService.GetAccount(personeelslidAccountId);
                var personeelsleden = account!.Personeelsleden.ToList();
                var personeelslid = personeelsleden.FirstOrDefault();
                var personeelslidId = personeelslid.PersoneelslidId;
                return RedirectToAction(nameof(PersoneelslidDetails), new { id = personeelslidId });
            }
            else
                return NotFound();
        }

        public IActionResult PersoneelToevoegen()
        {
            var vm = new PersoneelToevoegenViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Toevoegen(PersoneelToevoegenViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var account = new Personeelslidaccount();
                var lid = new Personeelslid();
                account.Emailadres = vm.Emailadres;
                account.Paswoord = _securityService.EncrypteerPaswoord( vm.Paswoord);
                account.Disabled = vm.Disabled;

                lid.Voornaam = vm.Voornaam;
                lid.Familienaam = vm.Familienaam;
                lid.InDienst = vm.InDienst;
                lid.PersoneelslidAccount = account;

                account.Personeelsleden.Add(lid); 
                _securityService.PersoneelslidToevoegen(/*account,*/ lid);
            }
            return RedirectToAction("PersoneelsLeden");
        }

    [HttpGet]
    [AuthorizationGroup("Cwebsite")]
    public IActionResult PersoneelslidToevoegen(int id)
    {
        var personeelsleden = _securityService.GetAllPersoneelsledenNotInGroup(id);
        var vm = new PersoneelslidToevoegenAanGroepViewModel
        {
            SecuritygroepNaam = _securityService.GetSecuritygroep(id)!.Naam,
            SecuritygroepId = id
        };
        foreach (var p in personeelsleden)
        {
            vm.Personeelsleden.Add(new PersoneelslidAccountViewModel
            {
                Id = p.PersoneelslidId,
                Voornaam = p.Voornaam,
                Familienaam = p.Familienaam,
                Email = p.PersoneelslidAccount.Emailadres,
                Securitygroepen = p.SecurityGroepen.ToList(),
                Disabled = p.PersoneelslidAccount.Disabled
            });
        }

        return View(vm);
    }

    [HttpPost]
    [AuthorizationGroup("Cwebsite")]
    public IActionResult PersoneelslidToevoegen(int gebruikerId, int groepId)
    {
        _securityService.AddPersoneelslidToSecuritygroep(gebruikerId, groepId);

        return RedirectToAction(nameof(PersoneelslidToevoegen), groepId);
    }

    [HttpPost]
    [AuthorizationGroup("Cwebsite")]
    public IActionResult PersoneelslidVerwijderenUitSecuritygroep(int gebruikerId, int groepId)
    {
        _securityService.RemovePersoneelslidToSecuritygroep(gebruikerId, groepId);

            return RedirectToAction(nameof(SecuritygroepDetails), new { id = groepId });
        }

        [HttpGet]
    [AuthorizationGroup("Cwebsite")]
    public async Task<IActionResult> GebruikerWijzigen(int id)
        {
            var account = await _securityService.GetPersoneelslidaccountAsync(id);
            if (account == null) return NotFound();
            var vm = new GebruikerWijzigenViewModel();
            vm.PersoneelslidAccountId = id;
            vm.Emailadres = account.Emailadres;
            //vm.Disabled = account.Disabled;
            vm.Voornaam = account.Personeelsleden.First().Voornaam;
            vm.Familienaam = account.Personeelsleden.First().Familienaam;
            vm.InDienst = account.Personeelsleden.First().InDienst ?? false;
            return View(vm);
        }

        [HttpPost]
    [AuthorizationGroup("Cwebsite")]
    public async Task<IActionResult> GebruikerWijzigen(GebruikerWijzigenViewModel vm)
        {
            if (this.ModelState.IsValid)
            {
                var account = await _securityService.GetPersoneelslidaccountAsync(vm.PersoneelslidAccountId);
                if (account == null) return NotFound();
                account.Emailadres = vm.Emailadres;           
                account.Personeelsleden.First().Voornaam = vm.Voornaam;
                account.Personeelsleden.First().Familienaam = vm.Familienaam;
                account.Personeelsleden.First().InDienst = vm.InDienst;
                if (vm.PaswoordResetten) account.Paswoord = _securityService.EncrypteerPaswoord("Prularia"); //na testen in database terug aanpassen
                _securityService.UpdateAccount(account);
                return RedirectToAction(nameof(PersoneelslidDetails), new { id = vm.PersoneelslidAccountId });
            }
            return View("GebruikerWijzigen",vm);
        }
    }
