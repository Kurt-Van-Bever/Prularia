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

<<<<<<< HEAD
    public virtual ICollection<Inkomendeleveringslijnen> Inkomendeleveringslijnen { get; set; } = new List<Inkomendeleveringslijnen>();
=======
    public virtual ICollection<Inkomendeleveringslijnen> Inkomendeleveringslijnens { get; set; } = new List<Inkomendeleveringslijnen>();
>>>>>>> 2dda2248c486c2040b30d32fc48cdcfbd5cad7e1
}
