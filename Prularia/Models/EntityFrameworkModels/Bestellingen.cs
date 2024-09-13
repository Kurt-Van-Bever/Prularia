using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Bestellingen
{
    public int BestelId { get; set; }

    public DateTime Besteldatum { get; set; }

    public int KlantId { get; set; }

    public bool Betaald { get; set; }

    public string? Betalingscode { get; set; }

    public int BetaalwijzeId { get; set; }

    public bool Annulatie { get; set; }

    public DateTime? Annulatiedatum { get; set; }

    public string? Terugbetalingscode { get; set; }

    public int BestellingsStatusId { get; set; }

    public bool ActiecodeGebruikt { get; set; }

    public string? Bedrijfsnaam { get; set; }

    public string? BtwNummer { get; set; }

    public string Voornaam { get; set; } = null!;

    public string Familienaam { get; set; } = null!;

    public int FacturatieAdresId { get; set; }

    public int LeveringsAdresId { get; set; }

<<<<<<< HEAD
    public virtual ICollection<Bestellijnen> Bestellijnen { get; set; } = new List<Bestellijnen>();
=======
    public virtual ICollection<Bestellijnen> Bestellijnens { get; set; } = new List<Bestellijnen>();
>>>>>>> 2dda2248c486c2040b30d32fc48cdcfbd5cad7e1

    public virtual Bestellingsstatussen BestellingsStatus { get; set; } = null!;

    public virtual Betaalwijze Betaalwijze { get; set; } = null!;

    public virtual Adressen FacturatieAdres { get; set; } = null!;

    public virtual Klanten Klant { get; set; } = null!;

    public virtual Adressen LeveringsAdres { get; set; } = null!;

<<<<<<< HEAD
    public virtual ICollection<Uitgaandeleveringen> Uitgaandeleveringen { get; set; } = new List<Uitgaandeleveringen>();
=======
    public virtual ICollection<Uitgaandeleveringen> Uitgaandeleveringens { get; set; } = new List<Uitgaandeleveringen>();
>>>>>>> 2dda2248c486c2040b30d32fc48cdcfbd5cad7e1
}
