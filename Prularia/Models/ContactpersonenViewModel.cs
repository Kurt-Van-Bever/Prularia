﻿namespace Prularia.Models;

public class ContactpersonenViewModel
{
    public int KlantId { get; set; }
    public string Voornaam { get; set; } = null!;

    public string Familienaam { get; set; } = null!;

    public string Functie { get; set; } = null!;

    public string Emailadres { get; set; } = null!;
}