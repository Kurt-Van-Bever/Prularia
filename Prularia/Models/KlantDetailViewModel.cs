namespace Prularia.Models;

public class KlantDetailViewModel
{
    public int KlantId { get; set; }
    public string Voornaam { get; set; } = null!;

    public string Familienaam { get; set; } = null!;

    public string Emailadres { get; set; } = null!;

    public string Naam { get; set; } = null!;

    public string BtwNummer { get; set; } = null!;

    public virtual ICollection<Bestelling> Bestellingen { get; set; } = new List<Bestelling>();

    public virtual Adres FacturatieAdres { get; set; } = null!;

    public virtual Adres LeveringsAdres { get; set; } = null!;

    public virtual Natuurlijkepersoon? Natuurlijkepersoon { get; set; }

    public virtual Rechtspersoon? Rechtspersoon { get; set; }

    public virtual ICollection<Uitgaandelevering> Uitgaandeleveringen { get; set; } = new List<Uitgaandelevering>();
}
