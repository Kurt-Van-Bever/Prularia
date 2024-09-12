using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Veelgesteldevragenartikel
{
    public int VeelgesteldeVragenArtikelId { get; set; }

    public int ArtikelId { get; set; }

    public string Vraag { get; set; } = null!;

    public string Antwoord { get; set; } = null!;

    public virtual Artikelen Artikel { get; set; } = null!;
}
