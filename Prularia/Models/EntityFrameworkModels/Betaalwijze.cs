using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Betaalwijze
{
    public int BetaalwijzeId { get; set; }

    public string Naam { get; set; } = null!;


    public virtual ICollection<Bestellingen> Bestellingen { get; set; } = new List<Bestellingen>();

    public virtual ICollection<Bestellingen> Bestellingens { get; set; } = new List<Bestellingen>();

}
