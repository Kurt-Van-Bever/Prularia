using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Magazijnplaatsen
{
    public int MagazijnPlaatsId { get; set; }

    public int? ArtikelId { get; set; }

    public string Rij { get; set; } = null!;

    public int Rek { get; set; }

    public int Aantal { get; set; }

    public virtual Artikelen? Artikel { get; set; }

    public virtual ICollection<Inkomendeleveringslijnen> Inkomendeleveringslijnens { get; set; } = new List<Inkomendeleveringslijnen>();
}
