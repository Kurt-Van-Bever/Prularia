using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Klanten
{
    public int KlantId { get; set; }

    public int FacturatieAdresId { get; set; }

    public int LeveringsAdresId { get; set; }

    public virtual ICollection<Bestellingen> Bestellingens { get; set; } = new List<Bestellingen>();

    public virtual Adressen FacturatieAdres { get; set; } = null!;

    public virtual Adressen LeveringsAdres { get; set; } = null!;

    public virtual Natuurlijkepersonen? Natuurlijkepersonen { get; set; }

    public virtual Rechtspersonen? Rechtspersonen { get; set; }

    public virtual ICollection<Uitgaandeleveringen> Uitgaandeleveringens { get; set; } = new List<Uitgaandeleveringen>();
}
