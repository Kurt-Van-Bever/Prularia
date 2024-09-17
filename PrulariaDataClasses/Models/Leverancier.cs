﻿namespace Prularia.Models;

public partial class Leverancier
{
    public int LeveranciersId { get; set; }

    public string Naam { get; set; } = null!;

    public string BtwNummer { get; set; } = null!;

    public string Straat { get; set; } = null!;

    public string HuisNummer { get; set; } = null!;

    public string? Bus { get; set; }

    public int PlaatsId { get; set; }

    public string FamilienaamContactpersoon { get; set; } = null!;

    public string VoornaamContactpersoon { get; set; } = null!;

    public virtual ICollection<Artikel> Artikelen { get; set; } = new List<Artikel>();

    public virtual ICollection<Inkomendelevering> Inkomendeleveringen { get; set; } = new List<Inkomendelevering>();

    public virtual Plaats Plaats { get; set; } = null!;
}