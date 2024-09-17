namespace Prularia.Models;

public partial class Adres
{
    public int AdresId { get; set; }

    public string Straat { get; set; } = null!;

    public string HuisNummer { get; set; } = null!;

    public string? Bus { get; set; }

    public int PlaatsId { get; set; }

    public bool? Actief { get; set; }

    public virtual ICollection<Bestelling> BestellingenFacturatieAdressen { get; set; } = new List<Bestelling>();

    public virtual ICollection<Bestelling> BestellingenLeveringsAdressen { get; set; } = new List<Bestelling>();

    public virtual ICollection<Klant> KlantenFacturatieAdressen { get; set; } = new List<Klant>();

    public virtual ICollection<Klant> KlantenLeveringsAdressen { get; set; } = new List<Klant>();

    public virtual Plaats Plaats { get; set; } = null!;
}
