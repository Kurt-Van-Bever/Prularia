using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Adressen
{
    public int AdresId { get; set; }

    public string Straat { get; set; } = null!;

    public string HuisNummer { get; set; } = null!;

    public string? Bus { get; set; }

    public int PlaatsId { get; set; }

    public bool? Actief { get; set; }

    public virtual ICollection<Bestellingen> BestellingenFacturatieAdres { get; set; } = new List<Bestellingen>();

    public virtual ICollection<Bestellingen> BestellingenLeveringsAdres { get; set; } = new List<Bestellingen>();

    public virtual ICollection<Klanten> KlantenFacturatieAdres { get; set; } = new List<Klanten>();

    public virtual ICollection<Klanten> KlantenLeveringsAdres { get; set; } = new List<Klanten>();

    public virtual Plaatsen Plaats { get; set; } = null!;
}
