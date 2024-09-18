using System.ComponentModel.DataAnnotations;

namespace Prularia.Models;

public partial class Bestelling
{
    public int BestelId { get; set; }

    public DateTime Besteldatum { get; set; }

    public int KlantId { get; set; }
    //deze
    public bool Betaald { get; set; }

    public string? Betalingscode { get; set; }

    public int BetaalwijzeId { get; set; }

    public bool Annulatie { get; set; }

    public DateTime? Annulatiedatum { get; set; }

    public string? Terugbetalingscode { get; set; }

    public int BestellingsStatusId { get; set; }

    public bool ActiecodeGebruikt { get; set; }
    //deze
    [MaxLength(45)]
    public string? Bedrijfsnaam { get; set; }
    //deze
    [MaxLength(45)]
    public string? BtwNummer { get; set; }
    //deze
    [MaxLength(45)]
    public string Voornaam { get; set; } = null!;
    //deze
    [MaxLength(45)]
    public string Familienaam { get; set; } = null!;

    public int FacturatieAdresId { get; set; }

    public int LeveringsAdresId { get; set; }

    public virtual ICollection<Bestellijn> Bestellijnen { get; set; } = new List<Bestellijn>();

    public virtual Bestellingsstatus BestellingsStatus { get; set; } = null!;

    public virtual Betaalwijze Betaalwijze { get; set; } = null!;

    public virtual Adres FacturatieAdres { get; set; } = null!;

    public virtual Klant Klant { get; set; } = null!;

    public virtual Adres LeveringsAdres { get; set; } = null!;

    public virtual ICollection<Uitgaandelevering> Uitgaandeleveringen { get; set; } = new List<Uitgaandelevering>();
}
