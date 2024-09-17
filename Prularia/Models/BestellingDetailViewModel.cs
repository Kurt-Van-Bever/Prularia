using Prularia.Models.EntityFrameworkModels;

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


        public virtual Bestellingsstatussen BestellingsStatus { get; set; } = null!;

        public virtual Betaalwijze Betaalwijze { get; set; } = null!;

        public virtual Adressen FacturatieAdres { get; set; } = null!;

        public virtual Klanten Klant { get; set; } = null!;

        public virtual Adressen LeveringsAdres { get; set; } = null!;
    }
}
