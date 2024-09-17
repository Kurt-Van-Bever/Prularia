﻿namespace Prularia.Models;

public partial class Natuurlijkepersoon
{
    public int KlantId { get; set; }

    public string Voornaam { get; set; } = null!;

    public string Familienaam { get; set; } = null!;

    public int GebruikersAccountId { get; set; }

    public virtual Gebruikersaccount GebruikersAccount { get; set; } = null!;

    public virtual Klant Klant { get; set; } = null!;
}
