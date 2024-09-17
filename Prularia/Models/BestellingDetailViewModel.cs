namespace Prularia.Models;

public class BestellingDetailViewModel
{
    public int BestelId { get; set; }

    public DateTime Besteldatum { get; set; }

    public bool Betaald { get; set; }

    public string? Betalingscode { get; set; }

    public bool Annulatie { get; set; }

    public DateTime? Annulatiedatum { get; set; }

    public string? Terugbetalingscode { get; set; }

    public bool ActiecodeGebruikt { get; set; }

    public string? Bedrijfsnaam { get; set; }

    public string? BtwNummer { get; set; }

    public string Voornaam { get; set; } 

    public string Familienaam { get; set; } 

    public Bestellingsstatus BestellingsStatus { get; set; } = null!;

    public Betaalwijze Betaalwijze { get; set; } = null!;

    public Adres FacturatieAdres { get; set; } = null!;

    public Klant Klant { get; set; } = null!;

    public Adres LeveringsAdres { get; set; } = null!;

    public ICollection<Bestellijn> Bestellijnen { get; set; }
}
