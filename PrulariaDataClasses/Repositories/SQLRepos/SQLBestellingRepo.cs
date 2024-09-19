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

    public async Task<List<Bestelling>> GetBestellingen()
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
}
