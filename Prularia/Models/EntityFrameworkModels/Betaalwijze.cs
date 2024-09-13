using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Betaalwijze
{
    public int BetaalwijzeId { get; set; }

    public string Naam { get; set; } = null!;

<<<<<<< HEAD
    public virtual ICollection<Bestellingen> Bestellingen { get; set; } = new List<Bestellingen>();
=======
    public virtual ICollection<Bestellingen> Bestellingens { get; set; } = new List<Bestellingen>();
>>>>>>> 2dda2248c486c2040b30d32fc48cdcfbd5cad7e1
}
