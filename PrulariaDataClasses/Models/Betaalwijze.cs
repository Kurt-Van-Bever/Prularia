﻿namespace Prularia.Models;

public partial class Betaalwijze
{
    public int BetaalwijzeId { get; set; }

    public string Naam { get; set; } = null!;

    public virtual ICollection<Bestelling> Bestellingen { get; set; } = new List<Bestelling>();
}
