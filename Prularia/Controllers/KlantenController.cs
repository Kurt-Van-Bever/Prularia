﻿using Microsoft.AspNetCore.Mvc;
using Prularia.Filters;
using Prularia.Models;
using Prularia.Services;

namespace Prularia.Controllers;

//[AuthorizationGroup("Cwebsite")]
public class KlantenController : Controller
{
    private readonly KlantService _klantService;
    public KlantenController(KlantService klantService)
    {
        _klantService = klantService;
    }

    public async Task<IActionResult> Index()
    {
        string klantType = TempData["KlantType"] as string ?? "natuurlijk";
        TempData.Keep("KlantType");

        if (klantType == "natuurlijk")
        {
            var natuurlijkePersonen = await _klantService.GetNatuurlijkePersonenAsync();
            var vm = natuurlijkePersonen.Select(n => new NatuurlijkePersoonViewModel
            {
                KlantId = n.KlantId,
                Voornaam = n.Natuurlijkepersoon!.Voornaam,
                Achternaam = n.Natuurlijkepersoon.Familienaam,
                Postcode = n.FacturatieAdres.Plaats.Postcode,
                Email = n.Natuurlijkepersoon.GebruikersAccount.Emailadres
            }).ToList();

            return View("NatuurlijkePersonenView", vm);
        }
        else
        {
            var rechtspersonen = await _klantService.GetRechtspersonenAsync();
            var vm = rechtspersonen.Select(r => new RechtspersoonViewModel
            {
                KlantId = r.KlantId,
                Naam = r.Rechtspersoon!.Naam,
                BTWNummer = r.Rechtspersoon.BtwNummer,
                Postcode = r.FacturatieAdres.Plaats.Postcode,
            }).ToList();

            return View("RechtspersonenView", vm);
        }
    }    
    
    [HttpPost]
    public IActionResult ToggleKlantType(string huidigType)
    {
        if (huidigType == "natuurlijk")
        {
            TempData["KlantType"] = "rechtspersoon";
        }
        else
        {
            TempData["KlantType"] = "natuurlijk";
        }

        return RedirectToAction("Index");
    }

    public IActionResult AdresWijzigenKlant(int id, string type)
    {

        var klant = _klantService.Get(id);
        if(klant == null) return NotFound();
        var vm = new AdresWijzigenFormModel();
        vm.KlantId = klant.KlantId;
        vm.Type = type;
        return View(vm);
    }

    [HttpPost]
    public IActionResult AdresWijzigenDoorvoeren(AdresWijzigenFormModel form)
    {
        
        if(this.ModelState.IsValid)
        {
            var klant = _klantService.Get(form.KlantId);
            int? plaatsId = _klantService.GetPlaatsId(form.PostCode);
            if(plaatsId == null) return  View("AdresWijzigenKlant", form);
            var bestaandAdres =  _klantService.CheckAdres(form.Straat, form.HuisNummer, plaatsId);
            
            if (bestaandAdres == null)
            {
                Adres adres = new Adres()
                {
                    Straat = form.Straat,
                    HuisNummer = form.HuisNummer,
                    Bus = form.Bus ?? string.Empty,
                    PlaatsId = plaatsId ?? 0,
                    Actief = true
                    
                };
                _klantService.AdresToevoegenTabel(adres);

                Adres oudeAdres = new Adres();
                if (form.Type == "Facturatie")
                {
                    oudeAdres = _klantService.GetAdres(klant.FacturatieAdresId);
                    klant.FacturatieAdresId = adres.AdresId;
                }
                else if (form.Type == "Levering")
                {
                    oudeAdres = _klantService.GetAdres(klant.LeveringsAdresId);
                    klant.LeveringsAdresId = adres.AdresId;
                }

                _klantService.Update(klant);
                oudeAdres.Actief = false;
                //oudeadresID pakken en dit in klantenlist.Contains doen? om te zien of dit adres actief is of niet
                _klantService.UpdateAdres(oudeAdres);

                TempData["Gelukt"] = "Adres is succesvol gewijzigd";
                return RedirectToAction(nameof(Details), new { id = klant.KlantId });
            }

            int bestaandAdresId = bestaandAdres.AdresId;

            if (form.Type == "Facturatie")
            {
                klant.FacturatieAdresId = bestaandAdresId; 
            }
            else if (form.Type == "Levering")
            {
                klant.LeveringsAdresId = bestaandAdresId;
            }
            bestaandAdres.Actief =true; //indien het op false zou staan wordt het nu op true gezet
            _klantService.UpdateAdres(bestaandAdres);

            _klantService.Update(klant);
            TempData["Gelukt"] = "Adres is succesvol gewijzigd";
            return RedirectToAction(nameof(Details), new { id = klant.KlantId });
        }
         return View("AdresWijzigenKlant", form);
    }
  
   /* [HttpPost]
    public IActionResult WijzigingDoorvoeren(AdresWijzigenViewModel vm)
    {
        if (this.ModelState.IsValid)
        {
            var klant = _klantService.Get(vm.KlantId);
            klant!.FacturatieAdres = vm.FacturatieAdres;
            klant.LeveringsAdres= vm.LeveringsAdres;

            _klantService.Update(klant);
            return RedirectToAction(nameof(Details), new { id = vm.KlantId });
        }
        return View("Wijzigen", vm);
    }*/

    public async Task<IActionResult> Details(int id)
    {
        Klant? klant = await _klantService.GetKlant(id);
        if (klant == null) return NotFound();
        KlantDetailViewModel viewModel = new KlantDetailViewModel()
        {
            KlantId = klant.KlantId,
            Bestellingen = klant.Bestellingen,
            FacturatieAdres = klant.FacturatieAdres,
            LeveringsAdres = klant.LeveringsAdres,
            Natuurlijkepersoon = klant.Natuurlijkepersoon,
            Rechtspersoon = klant.Rechtspersoon,
            Uitgaandeleveringen = klant.Uitgaandeleveringen
        };
        return View(viewModel);
    }

    public async Task<IActionResult> ContactPersonen(int id)
    {
        ICollection<Contactpersoon> contactpersonen = await _klantService.GetContactpersonen(id);
        if (contactpersonen == null) return NotFound();
        ICollection<ContactpersonenViewModel> contacten = new List<ContactpersonenViewModel>();
        
        foreach(Contactpersoon c in contactpersonen)
        {
            contacten.Add(new ContactpersonenViewModel()
            {
                Voornaam = c.Voornaam,
                Familienaam = c.Familienaam,
                Functie = c.Functie,
                Emailadres = c.GebruikersAccount.Emailadres,
                Disable = c.GebruikersAccount.Disabled,
                ContactpersoonId = c.ContactpersoonId
            });
            
        }
        ViewBag.KlantId = id;
        return View(contacten);
    }
	public async Task<IActionResult> KlantBestellingen(int id)
	{
		ViewBag.KlantId = id;
		List<Bestelling?> bestellingen = new List<Bestelling?>();
		bestellingen = await _klantService.GetBestellingenByKlantAsync(id);
		return View(bestellingen);
	}

    [HttpPost]
    public async Task<IActionResult> DisabelenKlantPopupAsync(int id)
    {
        var klant = await _klantService.DisableKlantAsync(id);
        if (klant != null)
            return RedirectToAction(nameof(Details), new { id = klant.KlantId });
        else 
            return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ActivateKlantPopupAsync(int id)
    {
        var klant = await _klantService.ActivateKlantAsync(id);
        if (klant != null)
            return RedirectToAction(nameof(Details), new { id = klant.KlantId });
        else 
            return NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> DisabelenContactpersoonPopupAsync(int id)
    {
        var contactpersoon = await _klantService.DisableContactpersoonAsync(id);
        if (contactpersoon != null)
            return RedirectToAction(nameof(ContactPersonen), new { id = contactpersoon.KlantId });
        else 
            return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ActivateContactpersoonPopupAsync(int id)
    {
        var contactpersoon = await _klantService.ActivateContactpersoonAsync(id);
        if (contactpersoon != null)
            return RedirectToAction(nameof(ContactPersonen), new { id = contactpersoon.KlantId });
        else 
            return NotFound();
    }
}
