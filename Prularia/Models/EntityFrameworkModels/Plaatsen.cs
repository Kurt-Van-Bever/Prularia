using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Plaatsen
{
    public int PlaatsId { get; set; }

    public string Postcode { get; set; } = null!;

    public string Plaats { get; set; } = null!;

<<<<<<< HEAD
    public virtual ICollection<Adressen> Adressen { get; set; } = new List<Adressen>();
=======
    public virtual ICollection<Adressen> Adressens { get; set; } = new List<Adressen>();
>>>>>>> 2dda2248c486c2040b30d32fc48cdcfbd5cad7e1

    public virtual ICollection<Leverancier> Leveranciers { get; set; } = new List<Leverancier>();
}
