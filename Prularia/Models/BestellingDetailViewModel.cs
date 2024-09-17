namespace Prularia.Models
{
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


        public virtual Bestellingsstatus BestellingsStatus { get; set; } = null!;

        public virtual Betaalwijze Betaalwijze { get; set; } = null!;

        public virtual Adres FacturatieAdres { get; set; } = null!;

        public virtual Klant Klant { get; set; } = null!;

        public virtual Adres LeveringsAdres { get; set; } = null!;


        public virtual ICollection<Bestellijn> Bestellijnen { get; set; } = null;
    }
}
