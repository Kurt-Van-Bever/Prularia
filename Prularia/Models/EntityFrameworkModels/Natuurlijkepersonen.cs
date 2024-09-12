using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Natuurlijkepersonen
{
    public int KlantId { get; set; }

    public string Voornaam { get; set; } = null!;

    public string Familienaam { get; set; } = null!;

    public int GebruikersAccountId { get; set; }

    public virtual Gebruikersaccount GebruikersAccount { get; set; } = null!;

    public virtual Klanten Klant { get; set; } = null!;
}
