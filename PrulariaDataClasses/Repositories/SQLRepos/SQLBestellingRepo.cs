using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Prularia.Models;
using System.Buffers;
using System.Globalization;
using System.Numerics;

namespace Prularia.Repositories;

public class SQLBestellingRepo : IBestellingRepo
{
    private readonly PrulariaContext _context;
    public SQLBestellingRepo(PrulariaContext context)
    {
        _context = context;
    }

    public async Task<List<Bestelling>> GetBestellingenAsync()
    {
        return await _context.Bestellingen
            .Include(bestelling => bestelling.Klant)
            .ThenInclude(bestelling => bestelling.Natuurlijkepersoon)
            .ThenInclude(bestelling => bestelling!.GebruikersAccount)
            .Include(bestelling => bestelling.BestellingsStatus)
            .ToListAsync();
    }


    public async Task<Bestelling?> GetAsync(int id)
    {
        return await _context.Bestellingen
            .Include(b => b.BestellingsStatus)
            .Include(b => b.Betaalwijze)
            .Include(b => b.Klant)
            .ThenInclude(k => k.Natuurlijkepersoon)
            .ThenInclude(np => np.GebruikersAccount)
            .Include(b => b.Klant)
            .ThenInclude(k => k.Rechtspersoon)
            .ThenInclude(rp => rp.Contactpersonen)
            .ThenInclude(cp => cp.GebruikersAccount)
            .Include(b => b.FacturatieAdres).ThenInclude(fa => fa.Plaats)
            .Include(b => b.LeveringsAdres).ThenInclude(la => la.Plaats)
            .Include(b => b.Bestellijnen).ThenInclude(l => l.Artikel)
            .FirstOrDefaultAsync(b => b.BestelId == id);
    }   

  
    public async Task<List<Bestelling>> SearchBestelling(string searchValue)
    {




        if (searchValue.IsNullOrEmpty())
        {
            return await GetBestellingenAsync();
        }

            return await _context.Bestellingen
            .Include(bestelling => bestelling.Klant)
            .ThenInclude(bestelling => bestelling.Natuurlijkepersoon)
            .ThenInclude(bestelling => bestelling!.GebruikersAccount)
            .Include(bestelling => bestelling.BestellingsStatus)
            .Where(bestelling => 
            bestelling.Bedrijfsnaam!.ToUpper().StartsWith(searchValue.ToUpper()) 
            || bestelling.BtwNummer!.ToUpper().StartsWith(searchValue.ToUpper())
            || bestelling.Klant.Natuurlijkepersoon!.Familienaam.ToUpper().StartsWith(searchValue.ToUpper())
            || bestelling.Klant.Natuurlijkepersoon!.Voornaam.ToUpper().StartsWith(searchValue.ToUpper())
            || bestelling.BestellingsStatus.Naam!.ToUpper().StartsWith(searchValue.ToUpper())
            || bestelling.Klant.Natuurlijkepersoon.GebruikersAccount.Emailadres!.ToUpper().StartsWith(searchValue.ToUpper())
         

            ).ToListAsync();
            

    }

    public Task<List<Bestelling>> GetBestellingen()
    {
        throw new NotImplementedException();
    }

    public async Task<Bestelling?> AnnulerenAsync(int id)
    {
        var bestelling = await _context.Bestellingen.FindAsync(id);
        bestelling!.Annulatie = true;
        bestelling.Annulatiedatum = DateTime.Now;
        bestelling.BestellingsStatusId = 3; //Deze lijn eruit halen als se status niet mag worden aangepast.
        await _context.SaveChangesAsync();
        return bestelling;
    }
}





