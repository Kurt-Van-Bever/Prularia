﻿using Prularia.Models;
using Prularia.Repositories;

namespace Prularia.Services;

public class BestellingService
{
    private readonly IBestellingRepo _bestellingRepo;
    public BestellingService(IBestellingRepo bestellingRepo)
    {
        _bestellingRepo = bestellingRepo;
    }

    public async Task<List<Bestelling>> GetBestellingenAsync()
    {
        return await _bestellingRepo.GetBestellingenAsync();
    }


    public async Task<Bestelling?> GetAsync(int id)
    {
        return await _bestellingRepo.GetAsync(id);
    }
    
    public async Task AnnulerenAsync(int id)
    {
        await _bestellingRepo.AnnulerenAsync(id);
    }

    public async Task<List<Bestelling>> SearchBestellingAsync(string searchValue, string sorteerOptie)
    {

        List<Bestelling> Bestellingen = await _bestellingRepo.SearchBestelling(searchValue);



        if (sorteerOptie == "alfabetisch") {
            return Bestellingen.OrderBy(bestelling => bestelling.Voornaam).ThenBy(bestelling => bestelling.Familienaam).ToList(); 
        }

        if(sorteerOptie == "datum")
        {
        
            return Bestellingen.OrderByDescending(bestelling => bestelling.Besteldatum).ToList();
        }

        if(sorteerOptie == "status")
        {

            return Bestellingen.OrderBy(bestelling => bestelling.BestellingsStatus.Naam).ToList();
        }

        return Bestellingen;
    }
}
