namespace Prularia.Models;

public class BestellingenViewModel
{
    public int BestelId { get; set; }
    public DateTime Besteldatum { get; set; }
    public string? Voornaam { get; set; }
    public string? Familienaam {  get; set; }
    public string? Emailadres { get; set; }
    public string? Bedrijfsnaam { get; set; }
    public string? BtwNummer { get; set; }
    public Bestellingsstatus BestellingsStatus { get; set; }
}
