namespace Prularia.Models;

public class PersoneelToevoegenViewModel
{
    public string? Voornaam { get; set; }
    public string? Familienaam { get; set; }
    public bool? InDienst {  get; set; }
    public string? Emailadres { get; set; }
    public string Paswoord {  get; set; }
    public List<Securitygroep> Securitygroepen { get; set; } = new List<Securitygroep>();
    public bool Disabled { get; set; }
}
