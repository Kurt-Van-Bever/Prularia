using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Klanten
{
    public int KlantId { get; set; }

    public int FacturatieAdresId { get; set; }

    public int LeveringsAdresId { get; set; }

<<<<<<< HEAD
    public virtual ICollection<Bestellingen> Bestellingen { get; set; } = new List<Bestellingen>();
=======
    public virtual ICollection<Bestellingen> Bestellingens { get; set; } = new List<Bestellingen>();
>>>>>>> 2dda2248c486c2040b30d32fc48cdcfbd5cad7e1

    public virtual Adressen FacturatieAdres { get; set; } = null!;

    public virtual Adressen LeveringsAdres { get; set; } = null!;

    public virtual Natuurlijkepersonen? Natuurlijkepersonen { get; set; }

    public virtual Rechtspersonen? Rechtspersonen { get; set; }

<<<<<<< HEAD
    public virtual ICollection<Uitgaandeleveringen> Uitgaandeleveringen { get; set; } = new List<Uitgaandeleveringen>();
=======
    public virtual ICollection<Uitgaandeleveringen> Uitgaandeleveringens { get; set; } = new List<Uitgaandeleveringen>();
>>>>>>> 2dda2248c486c2040b30d32fc48cdcfbd5cad7e1
}
