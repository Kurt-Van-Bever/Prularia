using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Inkomendeleveringslijnen
{
    public int InkomendeLeveringsId { get; set; }

    public int ArtikelId { get; set; }

    public int AantalGoedgekeurd { get; set; }

    public int AantalTeruggestuurd { get; set; }

    public int MagazijnPlaatsId { get; set; }

    public virtual Artikelen Artikel { get; set; } = null!;

<<<<<<< HEAD
    public virtual Inkomendeleveringen InkomendeLevering { get; set; } = null!;
=======
    public virtual Inkomendeleveringen InkomendeLeverings { get; set; } = null!;
>>>>>>> 2dda2248c486c2040b30d32fc48cdcfbd5cad7e1

    public virtual Magazijnplaatsen MagazijnPlaats { get; set; } = null!;
}
