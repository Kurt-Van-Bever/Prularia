﻿namespace Prularia.Models;

public partial class Contactpersoon
{
    public int ContactpersoonId { get; set; }

    public string Voornaam { get; set; } = null!;

    public string Familienaam { get; set; } = null!;

    public string Functie { get; set; } = null!;

    public int KlantId { get; set; }

    public int GebruikersAccountId { get; set; }

    public virtual Gebruikersaccount GebruikersAccount { get; set; } = null!;

    public virtual Rechtspersoon Klant { get; set; } = null!;
}
