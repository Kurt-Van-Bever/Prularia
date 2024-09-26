namespace Prularia.Models;

public class PersoneelToevoegenViewModel
{
    public string? Voornaam { get; set; }
    public string? Familienaam { get; set; }
    public bool? InDienst {  get; set; }
    public string? Emailadres { get; set; }
    public string Paswoord {  get; set; }
    public bool Indienst { get; set; }
    public List<Securitygroep> Securitygroepen { get; set; }
    public int SelectedSecuritygroepId { get; set; }
    public bool Disabled { get; set; }
}
