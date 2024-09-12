using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Plaatsen
{
    public int PlaatsId { get; set; }

    public string Postcode { get; set; } = null!;

    public string Plaats { get; set; } = null!;

    public virtual ICollection<Adressen> Adressens { get; set; } = new List<Adressen>();

    public virtual ICollection<Leverancier> Leveranciers { get; set; } = new List<Leverancier>();
}
