using System.ComponentModel.DataAnnotations;

namespace Prularia.Models;

public class BestellingWijzigenViewModel
{
    public int BestelId { get; set; }
    public bool Betaald { get; set; }

    [MaxLength(45)]
    public string? Bedrijfsnaam { get; set; }

    [MaxLength(45)]
    public string? BtwNummer { get; set; }

    [MaxLength(45)]
    public string Voornaam { get; set; } = null!;

    [MaxLength(45)]
    public string Familienaam { get; set; } = null!;
}
