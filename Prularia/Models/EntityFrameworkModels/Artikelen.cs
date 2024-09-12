using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Artikelen
{
    public int ArtikelId { get; set; }

    public string Ean { get; set; } = null!;

    public string Naam { get; set; } = null!;

    public string Beschrijving { get; set; } = null!;

    public decimal Prijs { get; set; }

    public int GewichtInGram { get; set; }

    public int Bestelpeil { get; set; }

    public int Voorraad { get; set; }

    public int MinimumVoorraad { get; set; }

    public int MaximumVoorraad { get; set; }

    public int Levertijd { get; set; }

    public int AantalBesteldLeverancier { get; set; }

    public int MaxAantalInMagazijnPlaats { get; set; }

    public int LeveranciersId { get; set; }

    public virtual ICollection<Artikelleveranciersinfolijnen> Artikelleveranciersinfolijnens { get; set; } = new List<Artikelleveranciersinfolijnen>();

    public virtual ICollection<Bestellijnen> Bestellijnens { get; set; } = new List<Bestellijnen>();

    public virtual ICollection<Inkomendeleveringslijnen> Inkomendeleveringslijnens { get; set; } = new List<Inkomendeleveringslijnen>();

    public virtual Leverancier Leveranciers { get; set; } = null!;

    public virtual ICollection<Magazijnplaatsen> Magazijnplaatsens { get; set; } = new List<Magazijnplaatsen>();

    public virtual ICollection<Veelgesteldevragenartikel> Veelgesteldevragenartikels { get; set; } = new List<Veelgesteldevragenartikel>();

    public virtual ICollection<Wishlistitem> Wishlistitems { get; set; } = new List<Wishlistitem>();

    public virtual ICollection<Categorieen> Categories { get; set; } = new List<Categorieen>();
}
