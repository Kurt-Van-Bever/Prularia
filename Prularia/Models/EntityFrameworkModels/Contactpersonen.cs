using System;
using System.Collections.Generic;

namespace Prularia.Models.EntityFrameworkModels;

public partial class Contactpersonen
{
    public int ContactpersoonId { get; set; }

    public string Voornaam { get; set; } = null!;

    public string Familienaam { get; set; } = null!;

    public string Functie { get; set; } = null!;

    public int KlantId { get; set; }

    public int GebruikersAccountId { get; set; }

    public virtual Gebruikersaccount GebruikersAccount { get; set; } = null!;

    public virtual Rechtspersonen Klant { get; set; } = null!;
}
