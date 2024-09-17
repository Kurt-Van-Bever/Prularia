namespace Prularia.Models;

public partial class Artikel
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

    public virtual ICollection<Artikelleveranciersinfolijn> Artikelleveranciersinfolijnen { get; set; } = new List<Artikelleveranciersinfolijn>();

    public virtual ICollection<Bestellijn> Bestellijnen { get; set; } = new List<Bestellijn>();

    public virtual ICollection<Inkomendeleveringslijn> Inkomendeleveringslijnen { get; set; } = new List<Inkomendeleveringslijn>();

    public virtual Leverancier Leveranciers { get; set; } = null!;

    public virtual ICollection<Magazijnplaats> Magazijnplaatsen { get; set; } = new List<Magazijnplaats>();

    public virtual ICollection<Veelgesteldevraagartikel> Veelgesteldevragenartikel { get; set; } = new List<Veelgesteldevraagartikel>();

    public virtual ICollection<Wishlistitem> Wishlistitems { get; set; } = new List<Wishlistitem>();

    public virtual ICollection<Categorie> Categorieen { get; set; } = new List<Categorie>();
}
