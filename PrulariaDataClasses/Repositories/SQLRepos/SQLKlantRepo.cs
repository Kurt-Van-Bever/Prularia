﻿using Microsoft.EntityFrameworkCore;
using Prularia.Models;

namespace Prularia.Repositories;

public class SQLKlantRepo : IKlantRepo
{
    private readonly PrulariaContext _context;
    public SQLKlantRepo(PrulariaContext context)
    {
        _context = context;
    }

    public async Task<List<Klant>> GetNatuurlijkePersonenAsync()
    {
        return await _context.Klanten
            .Where(k => k.Natuurlijkepersoon != null)
            .Include(k => k.Natuurlijkepersoon)
            .ThenInclude(n => n!.GebruikersAccount)
            .Include(k => k.FacturatieAdres)
            .ThenInclude(n => n.Plaats)
            .ToListAsync();
    }

    public async Task<List<Klant>> GetRechtspersonenAsync()
    {
        return await _context.Klanten
            .Where(k => k.Rechtspersoon != null)
            .Include(k => k.Rechtspersoon)      
            .Include(k => k.FacturatieAdres)
            .ThenInclude(f => f.Plaats)
            .ToListAsync();
    }

    public void Update(Klant klant)
    {
        if (klant != null)
        {
            _context.Klanten.Update(klant);
            _context.SaveChanges();
        }
    }

    public Klant? Get(int id) => _context.Klanten.Find(id);


    public async Task<ICollection<Contactpersoon>> GetContactpersonenAsync(int id)
    {
        var p = await _context.Rechtspersonen
            .Include(r => r.Contactpersonen)
            .ThenInclude(c =>c.GebruikersAccount)
            .FirstOrDefaultAsync(k => k.KlantId == id);
        return p.Contactpersonen;
    }

    public async Task<Klant?> GetKlantAsync(int id)
    {
        return await _context.Klanten
            .Include(k => k.Natuurlijkepersoon).ThenInclude(n => n!.GebruikersAccount)
            .Include(k => k.Rechtspersoon)
            .Include(k => k.FacturatieAdres).ThenInclude(f => f.Plaats)
            .Include(k => k.LeveringsAdres).ThenInclude(l => l.Plaats)
            .FirstOrDefaultAsync(k => k.KlantId == id);
    }

    
	public async Task<List<Bestelling?>> GetBestellingenByKlantAsync(int id)
	{
		return await _context.Bestellingen
			.Where(b => b.KlantId == id)
			.ToListAsync();
	}

    public async Task<Klant?> DisableKlantAsync(int id)
    {
        var klant = await GetKlantAsync(id);

        if (klant != null)
        {
            klant.Natuurlijkepersoon!.GebruikersAccount.Disabled = true;
            await _context.SaveChangesAsync();
        }
    
        return klant;
    }

    public async Task<Klant?> ActivateKlantAsync(int id)
    {
        var klant = await GetKlantAsync(id);

        if (klant != null)
        {
            klant.Natuurlijkepersoon!.GebruikersAccount.Disabled = false;
            await _context.SaveChangesAsync();
        }
    
        return klant;
    }

    public async Task<Contactpersoon?> DisableContactpersoonAsync(int id)
    {
        var contactpersoon = await _context.Contactpersonen
            .Include(c => c.GebruikersAccount)
            .FirstOrDefaultAsync(c => c.ContactpersoonId == id);

        if (contactpersoon != null)
        {
            contactpersoon.GebruikersAccount.Disabled = true;
            await _context.SaveChangesAsync();
        }
    
        return contactpersoon;
    }

    public async Task<Contactpersoon?> ActivateContactpersoonAsync(int id)
    {
        var contactpersoon = await _context.Contactpersonen
            .Include(c => c.GebruikersAccount)
            .FirstOrDefaultAsync(c => c.ContactpersoonId == id);

        if (contactpersoon != null)
        {
            contactpersoon.GebruikersAccount.Disabled = false;
            await _context.SaveChangesAsync();
        }

        return contactpersoon;
    }
}

