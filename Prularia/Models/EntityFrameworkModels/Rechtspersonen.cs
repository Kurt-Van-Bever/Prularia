using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Rechtspersonen
{
    public int KlantId { get; set; }

    public string Naam { get; set; } = null!;

    public string BtwNummer { get; set; } = null!;

<<<<<<< HEAD
    public virtual ICollection<Contactpersonen> Contactpersonen { get; set; } = new List<Contactpersonen>();
=======
    public virtual ICollection<Contactpersonen> Contactpersonens { get; set; } = new List<Contactpersonen>();
>>>>>>> 2dda2248c486c2040b30d32fc48cdcfbd5cad7e1

    public virtual Klanten Klant { get; set; } = null!;
}
