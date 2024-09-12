using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Rechtspersonen
{
    public int KlantId { get; set; }

    public string Naam { get; set; } = null!;

    public string BtwNummer { get; set; } = null!;

    public virtual ICollection<Contactpersonen> Contactpersonens { get; set; } = new List<Contactpersonen>();

    public virtual Klanten Klant { get; set; } = null!;
}
