using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Bestellijnen
{
    public int BestellijnId { get; set; }

    public int BestelId { get; set; }

    public int ArtikelId { get; set; }

    public int AantalBesteld { get; set; }

    public int AantalGeannuleerd { get; set; }

    public virtual Artikelen Artikel { get; set; } = null!;

    public virtual Bestellingen Bestel { get; set; } = null!;

    public virtual ICollection<Klantenreview> Klantenreviews { get; set; } = new List<Klantenreview>();
}
