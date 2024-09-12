using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Bestellingsstatussen
{
    public int BestellingsStatusId { get; set; }

    public string Naam { get; set; } = null!;

    public virtual ICollection<Bestellingen> Bestellingen { get; set; } = new List<Bestellingen>();
}
