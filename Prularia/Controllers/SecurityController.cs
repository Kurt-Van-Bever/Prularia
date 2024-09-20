﻿using Microsoft.AspNetCore.Mvc;
using Prularia.Models;
using Prularia.Services;
using Prularia.Filters;
using System.Text.Json;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Prularia.Models;
using Prularia.Services;

namespace Prularia.Controllers
{
    public class SecurityController : Controller
    {
        private readonly SecurityService _securityService;
        public SecurityController(SecurityService securityService)
        {
            _securityService = securityService;
        }

        public IActionResult Index()
        public const string SESSION_LOGGEDIN_USER = "LOGGEDIN_USERID";
        private readonly SecurityService _securityService;

        public SecurityController(SecurityService securityService)
        {
            _securityService = securityService;
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
                return RedirectToAction(nameof(BestellingenController.Index), "Bestellingen");
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
                int accountId = 1; // uitzoeken hoe je dit kan vinden
                var account = _securityService.GetAccount(accountId);

                if(!_securityService.VerifyPaswoord(vm.OudPaswoord, account!.Paswoord))
                {
                    ViewBag.ErrorMessage = "Foutief paswoord ingegeven.";
                    return View(new PaswoordViewModel());
                }

                if(vm.NieuwPaswoord != vm.NieuwPaswoordConfirmatie)
                {
                    ViewBag.ErrorMessage = "Nieuw paswoord kwam niet overeen met nieuw paswoord confirmatie.";
                    return View(new PaswoordViewModel());
                }

                _securityService.UpdatePassword(accountId, 
                    _securityService.EncrypteerPaswoord(vm.NieuwPaswoord));
                return RedirectToAction(nameof(Index));
            }
            return View (vm);
        }
    }
}
