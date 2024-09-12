using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

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

    public virtual ICollection<Artikelen> Artikelen { get; set; } = new List<Artikelen>();

    public virtual ICollection<Inkomendeleveringen> Inkomendeleveringen { get; set; } = new List<Inkomendeleveringen>();

    public virtual Plaatsen Plaats { get; set; } = null!;
}
