using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Prularia.Models;
using System.Buffers;
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
            .ThenInclude(bestelling => bestelling.GebruikersAccount)
            .Include(bestelling => bestelling.BestellingsStatus)
            .ToListAsync();
    }


    public async Task<Bestelling?> GetAsync(int id)
    {
        return await _context.Bestellingen
            .Include(b => b.BestellingsStatus)
            .Include(b => b.Betaalwijze)
            .Include(b => b.Klant)
            .Include(b => b.FacturatieAdres)
            .Include(b => b.LeveringsAdres)
            .Include(b => b.Bestellijnen).ThenInclude(l => l.Artikel)
            .FirstOrDefaultAsync(b => b.BestelId == id);
    }

    public void Update(Bestelling bestelling)
    {
        if (bestelling != null)
        {
            _context.Bestellingen.Update(bestelling);
            _context.SaveChanges();
        }
    }

    public Bestelling? Get(int id) => _context.Bestellingen.Find(id);

    public  async Task<Bestelling?> Annuleren(int id)
    {
        return await _context.Bestellingen
            .Include(bestelling => bestelling.Klant)
            .ThenInclude(bestelling => bestelling.Natuurlijkepersoon)
            .ThenInclude(bestelling => bestelling.GebruikersAccount)
            .Include(bestelling => bestelling.BestellingsStatus).ToListAsync();

    }

    public async Task<List<Bestelling>> SearchBestelling(string searchValue, string ZoekOptie)
    {
        if(ZoekOptie == "klantnaam" && searchValue != null)
        {
            return await _context.Bestellingen
              .Include(bestelling => bestelling.Klant)
              .ThenInclude(bestelling => bestelling.Natuurlijkepersoon)
              .ThenInclude(bestelling => bestelling.GebruikersAccount)
              .Include(bestelling => bestelling.BestellingsStatus)
              .Where(bestelling => bestelling.Klant.Natuurlijkepersoon.Voornaam.ToUpper().Contains(searchValue.ToUpper())).ToListAsync();

        }

        if(ZoekOptie == "klantfamillienaam" && searchValue != null)
        {
            return await _context.Bestellingen
             .Include(bestelling => bestelling.Klant)
             .ThenInclude(bestelling => bestelling.Natuurlijkepersoon)
             .ThenInclude(bestelling => bestelling.GebruikersAccount)
             .Include(bestelling => bestelling.BestellingsStatus)
             .Where(bestelling => bestelling.Klant.Natuurlijkepersoon.Familienaam.ToUpper().Contains(searchValue.ToUpper())).ToListAsync();
        }

		if (ZoekOptie == "btwnummer" && searchValue != null)
		{
			return await _context.Bestellingen
			 .Include(bestelling => bestelling.Klant)
			 .ThenInclude(bestelling => bestelling.Natuurlijkepersoon)
			 .ThenInclude(bestelling => bestelling.GebruikersAccount)
			 .Include(bestelling => bestelling.BestellingsStatus)
			 .Where(bestelling => bestelling.BtwNummer.Contains(searchValue)).ToListAsync();
		}


		if (ZoekOptie == "bedrijfsnaam" && searchValue != null)
		{
            return await _context.Bestellingen
             .Include(bestelling => bestelling.Klant)
             .ThenInclude(bestelling => bestelling.Natuurlijkepersoon)
             .ThenInclude(bestelling => bestelling.GebruikersAccount)
             .Include(bestelling => bestelling.BestellingsStatus)
             .Where(bestelling => bestelling.Bedrijfsnaam.ToUpper().Contains(searchValue.ToUpper())).ToListAsync();
		}



		//	  < option value = "bedrijfsnaam" > Bedrijfsnaam </ option >

		//< option value = "btwnummer" > BTW nummer </ option >

		//< option value = "klantnaam" > Klant voornaam </ option >

		//< option value = "klantfamillienaam" > Klant famillienaam </ option >




		return await _context.Bestellingen
	      .Include(bestelling => bestelling.Klant)
	      .ThenInclude(bestelling => bestelling.Natuurlijkepersoon)
	      .ThenInclude(bestelling => bestelling.GebruikersAccount)
	      .Include(bestelling => bestelling.BestellingsStatus).ToListAsync();

	}
        var bestelling = await _context.Bestellingen.FindAsync(id);
        bestelling!.Annulatie = true;
        bestelling.Annulatiedatum = DateTime.Now;
        bestelling.BestellingsStatusId = 3; //Deze lijn eruit halen als se status niet mag worden aangepast.
        await _context.SaveChangesAsync();
        return bestelling;
    }
}
